using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cardMage.Models;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace cardMage.Controllers
{

    public class CartasController : Controller
    {

        private MainContext db = new MainContext();

        private Carta getCarta(string id)
        {
            Carta carta = db.Cartas.AsQueryable<Carta>().First(e => e.Id == id);
            return carta;
        }

        //
        // GET: /Cartas/

        public ActionResult Index()
        {
            return View(db.Cartas.AsQueryable<Carta>().ToList());
        }

        //
        // GET: /Cartas/Details/5

        public ActionResult Details(string id = "")
        {
            Carta carta = getCarta(id);
            if (carta == null)
            {
                return HttpNotFound();
            }

            //ViewBag.TipoCartaID = new SelectList(db.TiposCarta, "Id", "Tipo");
            return View(carta);
        }

        //
        // GET: /Cartas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cartas/Create

        [HttpPost]
        public ActionResult Create(Carta carta)
        {
            if (ModelState.IsValid)
            {
                db.Cartas.Insert(carta);
                return RedirectToAction("Index");
            }

            return View(carta);
        }

        //
        // GET: /Cartas/Edit/5

        public ActionResult Edit(string id = "")
        {
            Carta carta = getCarta(id);
            if (carta == null)
            {
                return HttpNotFound();
            }
            return View(carta);
        }

        //
        // POST: /Cartas/Edit/5

        [HttpPost]
        public ActionResult Edit(Carta carta)
        {
            if (ModelState.IsValid)
            {
                db.Cartas.Save(carta);
                return RedirectToAction("Index");
            }
            return View(carta);
        }

        //
        // GET: /Cartas/Delete/5

        public ActionResult Delete(string id = "")
        {
            Carta carta = getCarta(id);
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
            Carta carta = getCarta(id);

            db.Cartas.Remove(Query.EQ("_id", id));

            return RedirectToAction("Index");
        }
    }
}