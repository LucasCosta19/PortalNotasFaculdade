using System.Web.Mvc;

namespace PortalNotasFaculdades.Areas.AdminPortal
{
    public class AdminPortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPortal_default",
                "AdminPortal/{controller}/{action}/{id}",
                new { controller = "UsuariosAdmin", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "PortalNotasFaculdades.Areas.AdminPortal.Controllers" }
            );
        }
    }
}