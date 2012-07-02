using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditacaoMVC.Areas.docente.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /alunos/Painel/

        public ActionResult Index()
        {
            if (Session["DocenteLogado"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }
    }
}