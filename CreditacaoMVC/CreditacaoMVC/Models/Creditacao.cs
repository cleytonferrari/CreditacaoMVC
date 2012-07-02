using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditacaoMVC.Models
{
    public class Creditacao
    {
        public int CreditacaoId { get; set; }

        public Aluno Aluno { get; set; }

        public IEnumerable<Docente> Docentes { get; set; }

        public string Cv { get; set; }

        public string AnexoA { get; set; }

        public string Comprovantes { get; set; }

        public string ParecerDoJuri { get; set; }

        public string ParecerDoCoordenador { get; set; }

        public string Status { get; set; }
    }
}