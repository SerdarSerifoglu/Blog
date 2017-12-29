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
using DAL;
using static BLL.Repository;

namespace SerdarBlog.Controllers
{
    public class KategoriController : Controller
    {
        private BlogContext db = new BlogContext();
        private KategoriRep krep = new KategoriRep();

        // GET: Kategori
        public ActionResult Index()
        {
            return View(krep.GetAll());
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int id)
        {
            Kategori kategori = krep.GetById(id);
            return View(kategori);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriId,KategoriBaslik,KategoriIcerik")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                krep.Insert(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int id)
        {
            Kategori kategori = krep.GetById(id);
            return View(kategori);
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriId,KategoriBaslik,KategoriIcerik")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                krep.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int id)
        {
            Kategori kategori = krep.GetById(id);
            return View(kategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = krep.GetById(id);
            krep.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
