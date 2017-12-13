using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult IcerikEkle(Yazi yeniIcerik)
        {
            BlogRepository br = new BlogRepository();
            br.YaziEkle(yeniIcerik);
            return View();
        }

       
    }
}