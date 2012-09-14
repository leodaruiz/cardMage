using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cardMage.Models;
using MongoDB.Driver.Linq;

namespace cardMage.Controllers
{
    public class BaralhoController : Controller
    {
        private MainContext db = new MainContext();

        //
        // GET: /Baralho/

        public ActionResult Index()
        {
            return View(db.Baralhos.AsQueryable<Baralho>().ToList());
        }

        //
        // GET: /Baralho/Details/5

        public ActionResult Details(string nome)
        {
            Baralho b = db.Baralhos.AsQueryable<Baralho>().First(x => x.Nome == nome);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        //
        // GET: /Baralho/Create

        public ActionResult Create()
        {
            //ViewBag.HeroiID = new SelectList(db.Cartas.Where(x => x.TipoCartaID == db.heroi.Id), "Id", "Nome");
            return View();
        }

        //
        // POST: /Baralho/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Baralho/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Baralho/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Baralho/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Baralho/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
