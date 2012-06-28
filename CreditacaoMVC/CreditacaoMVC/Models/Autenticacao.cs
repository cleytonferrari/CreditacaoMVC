using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditacaoMVC.Models
{
    public class Autenticacao
    {
        public int AutenticacaoId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}