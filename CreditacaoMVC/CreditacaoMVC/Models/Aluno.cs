using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditacaoMVC.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Email { get; set; }

        public Curso Curso { get; set; }

        public Autenticacao Autenticacao { get; set; }
    }
}