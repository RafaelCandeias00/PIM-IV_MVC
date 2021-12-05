using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelFazenda_PimIV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Consulta",
                "Consulta",
                new { controller = "Hotel", action = "Consulta" }
            );

            routes.MapRoute(
                "Consulta_CriarCadastro",
                "Consulta/CriarCadastro",
                new { controller = "Hotel", action = "CriarCadastro" }
            );

            routes.MapRoute(
                "Consulta_NovoCadastro",
                "Consulta/NovoCadastro",
                new {controller = "Hotel", action = "NovoCadastro"}
            );

            routes.MapRoute(
                "Consulta_EditarCadastro",
                "Consulta/{id}/EditarCadastro",
                new { controller = "Hotel", action = "EditarCadastro" , id = 0 }
            );

            routes.MapRoute(
                "Consulta_AlterarCadastro",
                "Consulta/{id}/AlterarCadastro",
                new { controller = "Hotel", action = "AlterarCadastro", id = 0 }
            );

            routes.MapRoute(
                "Consulta_ExcluirCadastro",
                "Consulta/{id}/ExcluirCadastro",
                new { controller = "Hotel", action = "ExcluirCadastro", id = 0 }
            );

            routes.MapRoute(
                "Contato",
                "Contato",
                new {controller = "Home", action = "contact"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
