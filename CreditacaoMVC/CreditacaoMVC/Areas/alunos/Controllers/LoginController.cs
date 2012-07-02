using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditacaoMVC.Models;

namespace CreditacaoMVC.Areas.alunos.Controllers
{
    public class LoginController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        public ActionResult Index()
        {
            //Toda vez que entra no login destroi a sessão atual, assim não precisa fazer logout
            //basta redirecionar o aluno para o login que ele já faz o logout
            Session["AlunoLogado"] = null;
            Session["AlunoNome"] = null;
            Session["AlunoId"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Login, string Senha)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Senha))
            {
                ModelState.AddModelError("Login", "Preencha o campo login e senha");
                return View();
            }
            var aluno =
                db.Alunos.Include(x => x.Autenticacao).FirstOrDefault(
                    x => x.Autenticacao.Login == Login && x.Autenticacao.Password == Senha);
            if (aluno != null)
            {
                Session["AlunoLogado"] = true;
                Session["AlunoNome"] = aluno.Nome;
                Session["AlunoId"] = aluno.AlunoId;
                return RedirectToAction("Index", "Painel");
            }

            return View();
        }
    }
}