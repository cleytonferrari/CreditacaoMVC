namespace CreditacaoMVC.Models
{
    public class UnidadeCurricular
    {
        public int UnidadeCurricularId { get; set; }

        public string Nome { get; set; }

        public int Ects { get; set; }

        public string Descricao { get; set; }

        public Curso Curso { get; set; }
    }
}