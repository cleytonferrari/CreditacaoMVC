using System.Web.Mvc;

namespace CreditacaoMVC.Areas.admistrador
{
    public class admistradorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admistrador";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admistrador_default",
                "admistrador/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}