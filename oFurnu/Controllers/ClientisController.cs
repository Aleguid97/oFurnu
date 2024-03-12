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
    public class ClientisController : Controller
    {
        private Pizzeria db = new Pizzeria();

        // GET: Clientis
        public ActionResult Index()
        {
            return View(db.Clienti.ToList());
        }

        // GET: Clientis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clienti clienti = db.Clienti.Find(id);
            if (clienti == null)
            {
                return HttpNotFound();
            }
            return View(clienti);
        }

        // GET: Clientis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientis/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cliente,Nome,Cognome,Indirizzo,Citta,CAP,Email,Password,Ruolo")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                db.Clienti.Add(clienti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clienti);
        }

        // GET: Clientis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clienti clienti = db.Clienti.Find(id);
            if (clienti == null)
            {
                return HttpNotFound();
            }
            return View(clienti);
        }

        // POST: Clientis/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cliente,Nome,Cognome,Indirizzo,Citta,CAP,Email,Password,Ruolo")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clienti);
        }

        // GET: Clientis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clienti clienti = db.Clienti.Find(id);
            if (clienti == null)
            {
                return HttpNotFound();
            }
            return View(clienti);
        }

        // POST: Clientis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clienti clienti = db.Clienti.Find(id);
            db.Clienti.Remove(clienti);
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
