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
    public class AlunoController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        //
        // GET: /Aluno/

        public ViewResult Index()
        {
            return View(db.Alunos.Include(x => x.Curso).Include(x => x.Autenticacao).ToList());
        }

        //
        // GET: /Aluno/Details/5

        public ViewResult Details(int id)
        {
            Aluno aluno =
                db.Alunos.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.AlunoId == id);
            return View(aluno);
        }

        //
        // GET: /Aluno/Create

        public ActionResult Create()
        {
            var aluno = new Aluno
                            {
                                Autenticacao = new Autenticacao(),
                                Curso = new Curso()
                            };
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(aluno);
        }

        //
        // POST: /Aluno/Create

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.Curso = db.Cursos.Find(aluno.Curso.CursoId);
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(aluno);
        }

        //
        // GET: /Aluno/Edit/5

        public ActionResult Edit(int id)
        {
            Aluno aluno = db.Alunos.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.AlunoId == id);
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(aluno);
        }

        //
        // POST: /Aluno/Edit/5

        [HttpPost]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var alunoSalvar = db.Alunos.Find(aluno.AlunoId);
                alunoSalvar.Nome = aluno.Nome;
                alunoSalvar.Numero = aluno.Numero;
                alunoSalvar.Email = aluno.Email;

                alunoSalvar.Autenticacao = db.Autenticacao.Find(aluno.Autenticacao.AutenticacaoId);
                alunoSalvar.Autenticacao.Login = aluno.Autenticacao.Login;

                if (!string.IsNullOrEmpty(aluno.Autenticacao.Password))
                    alunoSalvar.Autenticacao.Password = aluno.Autenticacao.Password;

                alunoSalvar.Curso = db.Cursos.Find(aluno.Curso.CursoId);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Curso.CursoId"] = new SelectList(db.Cursos, "CursoId", "Nome");
            return View(aluno);
        }

        //
        // GET: /Aluno/Delete/5

        public ActionResult Delete(int id)
        {
            Aluno aluno = db.Alunos.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.AlunoId == id);
            return View(aluno);
        }

        //
        // POST: /Aluno/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.AlunoId == id);
            db.Autenticacao.Remove(aluno.Autenticacao);
            db.Alunos.Remove(aluno);
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