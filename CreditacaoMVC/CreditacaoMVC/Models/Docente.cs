using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditacaoMVC.Models
{
    public class Docente
    {
        public int DocenteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Coordenador { get; set; }

        public bool Administrador { get; set; }

        public Curso Curso { get; set; }

        public Autenticacao Autenticacao { get; set; }

        public virtual Creditacao Creditacao { get; set; }
    }
}