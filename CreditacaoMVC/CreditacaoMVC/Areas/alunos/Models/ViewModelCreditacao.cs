using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditacaoMVC.Areas.alunos.Models
{
    public class ViewModelCreditacao
    {
        public string Curso { get; set; }

        public HttpPostedFileBase Cv { get; set; }

        public HttpPostedFileBase AnexoA { get; set; }

        public HttpPostedFileBase Comprovantes { get; set; }
    }
}