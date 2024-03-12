using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oFurnu.Models;

namespace oFurnu.Controllers
{
    public class OrdiniController : Controller
    {
        private Pizzeria db = new Pizzeria();

        // GET: Ordini
        public ActionResult Index()
        {
            var ordini = db.Ordini.Include(o => o.Bibite).Include(o => o.Clienti).Include(o => o.Pizze);
            return View(ordini.ToList());
        }

        // GET: Ordini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // GET: Ordini/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID_Bibita = new SelectList(db.Bibite, "ID_Bibita", "Nome");
            ViewBag.FK_ID_Cliente = new SelectList(db.Clienti, "ID_Cliente", "Nome");
            ViewBag.FK_ID_Pizza = new SelectList(db.Pizze, "ID_Pizza", "Nome");
            return View();
        }

        // POST: Ordini/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ordine,FK_ID_Pizza,FK_ID_Bibita,FK_ID_Cliente,Indirizzo_Consegna,Quantita,Note,Totale")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Ordini.Add(ordini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID_Bibita = new SelectList(db.Bibite, "ID_Bibita", "Nome", ordini.FK_ID_Bibita);
            ViewBag.FK_ID_Cliente = new SelectList(db.Clienti, "ID_Cliente", "Nome", ordini.FK_ID_Cliente);
            ViewBag.FK_ID_Pizza = new SelectList(db.Pizze, "ID_Pizza", "Nome", ordini.FK_ID_Pizza);
            return View(ordini);
        }

        // GET: Ordini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID_Bibita = new SelectList(db.Bibite, "ID_Bibita", "Nome", ordini.FK_ID_Bibita);
            ViewBag.FK_ID_Cliente = new SelectList(db.Clienti, "ID_Cliente", "Nome", ordini.FK_ID_Cliente);
            ViewBag.FK_ID_Pizza = new SelectList(db.Pizze, "ID_Pizza", "Nome", ordini.FK_ID_Pizza);
            return View(ordini);
        }

        // POST: Ordini/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ordine,FK_ID_Pizza,FK_ID_Bibita,FK_ID_Cliente,Indirizzo_Consegna,Quantita,Note,Totale")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID_Bibita = new SelectList(db.Bibite, "ID_Bibita", "Nome", ordini.FK_ID_Bibita);
            ViewBag.FK_ID_Cliente = new SelectList(db.Clienti, "ID_Cliente", "Nome", ordini.FK_ID_Cliente);
            ViewBag.FK_ID_Pizza = new SelectList(db.Pizze, "ID_Pizza", "Nome", ordini.FK_ID_Pizza);
            return View(ordini);
        }

        // GET: Ordini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // POST: Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordini ordini = db.Ordini.Find(id);
            db.Ordini.Remove(ordini);
            db.SaveChanges();
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
