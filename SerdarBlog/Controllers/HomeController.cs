using BLL;
using Entity;
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
        public ActionResult IcerikEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IcerikEkle(Yazi yeniIcerik)
        {
            YaziRep br = new YaziRep();
            
            br.Insert(yeniIcerik);
            ViewBag.SeoTitle = yeniIcerik.SeoTitle;
            ViewBag.Description = yeniIcerik.SeoDesc;
            ViewBag.Keywords = yeniIcerik.SeoKeywords;
            return View();
        }
        public ActionResult YaziDetay(int id)
        {
            YaziRep br = new YaziRep();
            Yazi gelenYazi=br.GetById(id);
            ViewBag.SeoTitle = gelenYazi.SeoTitle;
            ViewBag.Description = gelenYazi.SeoDesc;
            ViewBag.Keywords = gelenYazi.SeoKeywords;

            return View(gelenYazi);
        }
       
    }
}