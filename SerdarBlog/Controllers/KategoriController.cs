using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BLL.Repository;

namespace SerdarBlog.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori yeniKategori)
        {
            if (yeniKategori != null)
            {
                KategoriRep krep = new KategoriRep();
                krep.Insert(yeniKategori);
            }
            return View();
        }
    }
}