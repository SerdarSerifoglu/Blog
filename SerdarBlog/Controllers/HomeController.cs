using BLL;
using Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BLL.Repository;

namespace SerdarBlog.Controllers
{
    public class HomeController : Controller
    {
        KategoriRep krep = new KategoriRep();
        YaziRep yrep = new YaziRep();
        public ActionResult Index()
        {
            var yazilar = yrep.GetAll();
            var tarihselsiraliyazilar = yazilar.OrderByDescending(x => x.EklenmeTarihi);
            return View(tarihselsiraliyazilar);
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult IcerikEkle()
        {

            ViewBag.KategoriId = new SelectList(krep.GetAll(), "KategoriId", "KategoriBaslik");
            
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult IcerikEkle(Yazi yeniIcerik)
        {
            yeniIcerik.KullaniciId = User.Identity.GetUserId();
            ViewBag.KategoriId = new SelectList(krep.GetAll(), "KategoriId", "KategoriBaslik",yeniIcerik.KategoriId);
            yrep.Insert(yeniIcerik);
            ViewBag.SeoTitle = yeniIcerik.SeoTitle;
            ViewBag.Description = yeniIcerik.SeoDesc;
            ViewBag.Keywords = yeniIcerik.SeoKeywords;


            return View();
        }
        public ActionResult YaziDetay(int id)
        {
            YaziRep br = new YaziRep();
           Yazi gelenYazi = br.GetById(id);
            ViewBag.SeoTitle = gelenYazi.SeoTitle;
            ViewBag.Description = gelenYazi.SeoDesc;
            ViewBag.Keywords = gelenYazi.SeoKeywords;

            return View(gelenYazi);
        }

    }
}