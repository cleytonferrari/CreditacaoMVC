using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditacaoMVC.Models;

namespace CreditacaoMVC.Areas.docente.Controllers
{
    public class LoginController : Controller
    {
        private CreditacaoContexto db = new CreditacaoContexto();

        public ActionResult Index()
        {
            //Toda vez que entra no login destroi a sessão atual, assim não precisa fazer logout
            //basta redirecionar o administrador para o login que ele já faz o logout
            Session["DocenteLogado"] = null;
            Session["DocenteNome"] = null;
            Session["DocenteNumero"] = null;
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
                Session["DocenteLogado"] = true;
                Session["DocenteNome"] = aluno.Nome;
                Session["DocenteNumero"] = aluno.Numero;
                return RedirectToAction("Index", "Painel");
            }

            return View();
        }
    }
}