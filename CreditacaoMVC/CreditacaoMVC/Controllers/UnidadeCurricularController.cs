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
    public class UnidadeCurricularController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        //
        // GET: /UnidadeCurricular/

        public ViewResult Index()
        {
            return View(db.UnidadeCurricular.Include(x => x.Curso).ToList());
        }

        //
        // GET: /UnidadeCurricular/Details/5

        public ViewResult Details(int id)
        {
            UnidadeCurricular unidadecurricular =
                db.UnidadeCurricular.Include(x => x.Curso).FirstOrDefault(x => x.UnidadeCurricularId == id);
            return View(unidadecurricular);
        }

        //
        // GET: /UnidadeCurricular/Create

        public ActionResult Create()
        {
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            var unidadeCurricular = new UnidadeCurricular { Curso = new Curso() };
            return View(unidadeCurricular);
        }

        //
        // POST: /UnidadeCurricular/Create

        [HttpPost]
        public ActionResult Create(UnidadeCurricular unidadecurricular)
        {
            if (ModelState.IsValid)
            {
                unidadecurricular.Curso = db.Cursos.Find(unidadecurricular.Curso.CursoId);
                db.UnidadeCurricular.Add(unidadecurricular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(unidadecurricular);
        }

        //
        // GET: /UnidadeCurricular/Edit/5

        public ActionResult Edit(int id)
        {
            UnidadeCurricular unidadecurricular = db.UnidadeCurricular.Include(x => x.Curso).FirstOrDefault(x => x.UnidadeCurricularId == id);
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome", unidadecurricular.Curso.CursoId);
            return View(unidadecurricular);
        }

        //
        // POST: /UnidadeCurricular/Edit/5

        [HttpPost]
        public ActionResult Edit(UnidadeCurricular unidadecurricular)
        {
            if (ModelState.IsValid)
            {
                //Ainda não descobri uma boa maneira de fazer isso, sou obrigado a buscar
                // no banco o registro para o Entity framework atachar ele, ai sim altero tudo dele
                //e depois mando salvar
                var unidadeCurricularSalvar = db.UnidadeCurricular.Find(unidadecurricular.UnidadeCurricularId);
                unidadeCurricularSalvar.Descricao = unidadecurricular.Descricao;
                unidadeCurricularSalvar.Ects = unidadecurricular.Ects;
                unidadeCurricularSalvar.Nome = unidadecurricular.Nome;
                unidadeCurricularSalvar.Curso = db.Cursos.Find(unidadecurricular.Curso.CursoId);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(unidadecurricular);
        }

        //
        // GET: /UnidadeCurricular/Delete/5

        public ActionResult Delete(int id)
        {
            UnidadeCurricular unidadecurricular = db.UnidadeCurricular.Include(x => x.Curso).FirstOrDefault(x => x.UnidadeCurricularId == id);
            return View(unidadecurricular);
        }

        //
        // POST: /UnidadeCurricular/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadeCurricular unidadecurricular = db.UnidadeCurricular.Include(x => x.Curso).FirstOrDefault(x => x.UnidadeCurricularId == id);
            db.UnidadeCurricular.Remove(unidadecurricular);
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