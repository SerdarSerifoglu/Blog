using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using SerdarBlog.Models;
using static BLL.Repository;
using Microsoft.AspNet.Identity;

namespace SerdarBlog.Controllers
{
    public class YaziController : Controller
    {
        KategoriRep krep = new KategoriRep();
        YaziRep yrep = new YaziRep();
        YorumRep yorumrep = new YorumRep();
        // GET: Yazi
        public ActionResult Index()
        {
            return View(yrep.GetAll());
        }
        public ActionResult BenKimim()
        {
            return View();
        }
        public ActionResult EnCokOkunanYazilar()
        {
            var tumyazilar=yrep.GetAll();
            var siraliokunmasayisi=tumyazilar.OrderByDescending(x => x.OkunmaSayisi);
            return View(siraliokunmasayisi);
        }
        // GET: Yazi/Detay/5
        public ActionResult Detay(int id)
        {
            Yazi gelenYazi = yrep.GetById(id);
            ViewBag.SeoTitle = gelenYazi.SeoTitle;
            ViewBag.Description = gelenYazi.SeoDesc;
            ViewBag.Keywords = gelenYazi.SeoKeywords;
            if (gelenYazi == null)
            {
                return HttpNotFound();
            }
            return View(gelenYazi);
        }

        // GET: Yazi/YaziEkle
        public ActionResult YaziEkle()
        {
            ViewBag.KategoriId = new SelectList(krep.GetAll(), "KategoriId", "KategoriBaslik");
            return View();
        }

        // POST: Yazi/YaziEkle
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult YaziEkle(Yazi yeniIcerik)
        {
            yeniIcerik.KullaniciId = User.Identity.GetUserId();
            ViewBag.KategoriId = new SelectList(krep.GetAll(), "KategoriId", "KategoriBaslik", yeniIcerik.KategoriId);
            yrep.Insert(yeniIcerik);
            ViewBag.SeoTitle = yeniIcerik.SeoTitle;
            ViewBag.Description = yeniIcerik.SeoDesc;
            ViewBag.Keywords = yeniIcerik.SeoKeywords;
            return View();
        }

        // GET: Yazi/Edit/5
        public ActionResult Edit(int id)
        {
           
            Yazi yazi = yrep.GetById(id);
            if (yazi == null)
            {
                return HttpNotFound();
            }
            return View(yazi);
        }

        // POST: Yazi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Yazi yazi)
        {
            if (ModelState.IsValid)
            {
                Yazi degisenYazi = yrep.GetById(yazi.YaziId);
                degisenYazi.BegenilmeSayisi = yazi.BegenilmeSayisi;
                degisenYazi.Etiket1 = yazi.Etiket1;
                degisenYazi.Etiket2 = yazi.Etiket2;
                degisenYazi.Etiket3 = yazi.Etiket3;
                degisenYazi.SeoDesc = yazi.SeoDesc;
                degisenYazi.SeoKeywords = yazi.SeoKeywords;
                degisenYazi.SeoTitle = yazi.SeoTitle;
                degisenYazi.YaziBasligi = yazi.YaziBasligi;
                degisenYazi.YaziIcerigi = yazi.YaziIcerigi;
                yrep.Update(degisenYazi);

                return RedirectToAction("Index");
            }
            return View(yazi);
        }

        // GET: Yazi/Delete/5
        public ActionResult Delete(int id)
        {

            Yazi yazi = yrep.GetById(id);
            if (yazi == null)
            {
                return HttpNotFound();
            }
            return View(yazi);
        }

        // POST: Yazi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yazi yazi = yrep.GetById(id);
            yrep.Delete(id);
            return RedirectToAction("Index");
        }
        
        public JsonResult YorumYap(string yorum,int YaziId)
        {
           
            if (yorum != null)
            {
                Yorum yeniyorum = new Yorum();
                yeniyorum.YorumlayanUyeId=User.Identity.GetUserId();
                yeniyorum.YotumlayanUsername = User.Identity.GetUserName();
                yeniyorum.YorumlananYaziId = YaziId;
                yeniyorum.YorumIcerik = yorum;
                yeniyorum.YorumlananYazi = yrep.GetById(YaziId);
                yorumrep.Insert(yeniyorum);
               
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult YorumSil(int id)
        {
            var kullaniciid = User.Identity.GetUserId();
            var yorum = yorumrep.GetById(id);
            var yazi = yrep.GetById(yorum.YorumlananYaziId);
            if (yorum.YorumlayanUyeId == kullaniciid)
            {
                yorumrep.Delete(id);
                return RedirectToAction("Detay", "Yazi", new { id = yazi.YaziId });
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult OkunmaSayisi(Yazi obj,int yaziid)
        {
            yrep.OkunmaSayisiArttir(obj, yaziid);
            return View();
        }
        public ActionResult Yorumlarim(string uyeid)
        {
           
                uyeid = User.Identity.GetUserId();
                var yorumlar = yorumrep.GetAll();
                var uyeninyorumlari = yorumlar.Where(x => x.YorumlayanUyeId == uyeid).ToList();
                return View(uyeninyorumlari);
          
           

            
        }
        
    }
}
