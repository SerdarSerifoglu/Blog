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
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult KategoriSec()
        //{
        //    KategoriRep krep = new KategoriRep();
        //    return View(krep.GetAll());
        //}
        //[HttpPost]
        //public ActionResult KategoriSec(Kategori k,int id)
        //{
        //    k.KategoriId = id;
        //    ViewBag.KategoriID = id;
        //    return RedirectToAction("IcerikEkle");
        //}
        [Authorize(Roles = "Admin")]
        public ActionResult IcerikEkle()
        {
            KategoriRep krep = new KategoriRep();
            ViewData["Kategori"]=krep.GetAll();
            
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult IcerikEkle(Yazi yeniIcerik)
        {

            YaziRep br = new YaziRep();
            yeniIcerik.KullaniciId = User.Identity.GetUserId();
            br.Insert(yeniIcerik);
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