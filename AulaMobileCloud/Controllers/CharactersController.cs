using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AulaMobileCloud.Models;
using AulaMobileCloud.Models.Contexto;

namespace AulaMobileCloud.Controllers
{
    public class CharactersController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Characters
        public ActionResult Index()
        {
            return View(db.Character.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Character.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Raça,Sexo,Planeta")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                db.Character.Add(characters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(characters);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Character.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // POST: Characters/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Raça,Sexo,Planeta")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(characters);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Character.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Characters characters = db.Character.Find(id);
            db.Character.Remove(characters);
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
