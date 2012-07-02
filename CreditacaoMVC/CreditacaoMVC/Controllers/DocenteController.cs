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
    public class DocenteController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        //
        // GET: /Aluno/

        public ViewResult Index()
        {
            return View(db.Docentes.Include(x => x.Curso).Include(x => x.Autenticacao).ToList());
        }

        //
        // GET: /Aluno/Details/5

        public ViewResult Details(int id)
        {
            Docente docente =
                db.Docentes.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.DocenteId == id);
            return View(docente);
        }

        //
        // GET: /Aluno/Create

        public ActionResult Create()
        {
            var docente = new Docente
            {
                Autenticacao = new Autenticacao(),
                Curso = new Curso()
            };
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(docente);
        }

        //
        // POST: /Aluno/Create

        [HttpPost]
        public ActionResult Create(Docente docente)
        {
            if (ModelState.IsValid)
            {
                docente.Curso = db.Cursos.Find(docente.Curso.CursoId);
                db.Docentes.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(docente);
        }

        //
        // GET: /Aluno/Edit/5

        public ActionResult Edit(int id)
        {
            Docente docente = db.Docentes.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.DocenteId == id);
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(docente);
        }

        //
        // POST: /Aluno/Edit/5

        [HttpPost]
        public ActionResult Edit(Docente docente)
        {
            if (ModelState.IsValid)
            {
                var docenteSalvar = db.Docentes.Find(docente.DocenteId);
                docenteSalvar.Nome = docente.Nome;
                docenteSalvar.Telefone = docente.Telefone;
                docenteSalvar.Email = docente.Email;
                docenteSalvar.Coordenador = docente.Coordenador;
                docenteSalvar.Administrador = docente.Administrador;

                docenteSalvar.Autenticacao = db.Autenticacao.Find(docente.Autenticacao.AutenticacaoId);
                docenteSalvar.Autenticacao.Login = docente.Autenticacao.Login;

                if (!string.IsNullOrEmpty(docente.Autenticacao.Password))
                    docenteSalvar.Autenticacao.Password = docente.Autenticacao.Password;

                docenteSalvar.Curso = db.Cursos.Find(docente.Curso.CursoId);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(docente);
        }

        //
        // GET: /Aluno/Delete/5

        public ActionResult Delete(int id)
        {
            Docente docente = db.Docentes.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.DocenteId == id);
            return View(docente);
        }

        //
        // POST: /Aluno/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docentes.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.DocenteId == id);
            db.Autenticacao.Remove(docente.Autenticacao);
            db.Docentes.Remove(docente);
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