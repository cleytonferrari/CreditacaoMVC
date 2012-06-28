using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditacaoMVC.Models;

namespace CreditacaoMVC.Controllers
{ 
    public class CursoController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        //
        // GET: /Curso/

        public ViewResult Index()
        {
            return View(db.Cursos.ToList());
        }

        //
        // GET: /Curso/Details/5

        public ViewResult Details(int id)
        {
            Curso curso = db.Cursos.Find(id);
            return View(curso);
        }

        //
        // GET: /Curso/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Curso/Create

        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(curso);
        }
        
        //
        // GET: /Curso/Edit/5
 
        public ActionResult Edit(int id)
        {
            Curso curso = db.Cursos.Find(id);
            return View(curso);
        }

        //
        // POST: /Curso/Edit/5

        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        //
        // GET: /Curso/Delete/5
 
        public ActionResult Delete(int id)
        {
            Curso curso = db.Cursos.Find(id);
            return View(curso);
        }

        //
        // POST: /Curso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
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