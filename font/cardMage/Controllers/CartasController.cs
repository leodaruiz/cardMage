using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cardMage.Models;

namespace cardMage.Controllers
{

    public class CartasController : Controller
    {

        private MainContext db = new MainContext();

        //
        // GET: /Cartas/

        public ActionResult Index()
        {
            return View(db.Cartas.ToList());
        }

        //
        // GET: /Cartas/Details/5

        public ActionResult Details(int id = 0)
        {
            Carta carta = db.Cartas.Find(id);
            if (carta == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoCartaID = new SelectList(db.TiposCarta, "Id", "Tipo");
            return View(carta);
        }

        //
        // GET: /Cartas/Create

        public ActionResult Create()
        {
            ViewBag.TipoCartaID = new SelectList(db.TiposCarta, "Id", "Tipo");
            return View();
        }

        //
        // POST: /Cartas/Create

        [HttpPost]
        public ActionResult Create(Carta carta)
        {
            if (ModelState.IsValid)
            {
                db.Cartas.Add(carta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carta);
        }

        //
        // GET: /Cartas/Edit/5

        public ActionResult Edit(string id = "")
        {
            Carta carta = db.Cartas.Find(id);
            if (carta == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoCartaID = new SelectList(db.TiposCarta, "Id", "Tipo");
            return View(carta);
        }

        //
        // POST: /Cartas/Edit/5

        [HttpPost]
        public ActionResult Edit(Carta carta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carta);
        }

        //
        // GET: /Cartas/Delete/5

        public ActionResult Delete(string id = "")
        {
            Carta carta = db.Cartas.Find(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            return View(carta);
        }

        //
        // POST: /Cartas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Carta carta = db.Cartas.Find(id);
            db.Cartas.Remove(carta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}