using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditacaoMVC.Areas.alunos.Models;
using CreditacaoMVC.Models;

namespace CreditacaoMVC.Areas.alunos.Controllers
{
    public class CreditacaoController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        //
        // GET: /alunos/Creditacao/

        public ActionResult Index()
        {
            if (Session["AlunoLogado"] == null)
                return RedirectToAction("Index", "Login");

            int id = (int)Session["AlunoId"];
            var listaDeCreditacaoDoAluno = db.Creditacao
                .Include(x => x.Aluno)
                .Include(x => x.Aluno.Curso)
                .Where(x => x.Aluno.AlunoId == id).ToList();

            return View(listaDeCreditacaoDoAluno);
        }

        //
        // GET: /alunos/Creditacao/Details/5

        public ActionResult Details(int id)
        {
            if (Session["AlunoLogado"] == null)
                return RedirectToAction("Index", "Login");

            var creditacao = db.Creditacao
                .Include(x => x.Aluno)
                .Include(x => x.Aluno.Curso).FirstOrDefault(x => x.CreditacaoId == id);
            return View(creditacao);
        }

        //
        // GET: /alunos/Creditacao/Create

        public ActionResult Create()
        {
            var viewModel = new ViewModelCreditacao();
            int id = (int)Session["AlunoId"];
            viewModel.Curso = db.Alunos.Include(x => x.Curso).FirstOrDefault(x => x.AlunoId == id).Curso.Nome;
            return View(viewModel);
        }

        //
        // POST: /alunos/Creditacao/Create

        [HttpPost]
        public ActionResult Create(ViewModelCreditacao viewModelCreditacao)
        {
            if (ModelState.IsValid)
            {
                string extensao, path;
                extensao = Path.GetExtension(viewModelCreditacao.AnexoA.FileName);
                string anexoA = Guid.NewGuid().ToString() + extensao;
                path = Path.Combine(Server.MapPath("~/Content/anexos/"), anexoA);
                viewModelCreditacao.AnexoA.SaveAs(path);

                extensao = Path.GetExtension(viewModelCreditacao.Cv.FileName);
                string cv = Guid.NewGuid().ToString() + extensao;
                path = Path.Combine(Server.MapPath("~/Content/anexos/"), cv);
                viewModelCreditacao.Cv.SaveAs(path);

                extensao = Path.GetExtension(viewModelCreditacao.Comprovantes.FileName);
                string comprovantes = Guid.NewGuid().ToString() + extensao;
                path = Path.Combine(Server.MapPath("~/Content/anexos/"), comprovantes);
                viewModelCreditacao.Comprovantes.SaveAs(path);

                var creditacao = new Creditacao();
                int id = (int)Session["AlunoId"];
                creditacao.Aluno = db.Alunos.Include(x => x.Curso).Include(x => x.Autenticacao).FirstOrDefault(x => x.AlunoId == id);
                creditacao.AnexoA = anexoA;
                creditacao.Comprovantes = comprovantes;
                creditacao.Cv = cv;

                creditacao.Status = "Novo";

                db.Creditacao.Add(creditacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModelCreditacao);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}