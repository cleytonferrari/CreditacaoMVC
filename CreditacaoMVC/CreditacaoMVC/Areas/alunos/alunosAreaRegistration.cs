using System.Web.Mvc;

namespace CreditacaoMVC.Areas.alunos
{
    public class alunosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "alunos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "alunos_default",
                "alunos/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}