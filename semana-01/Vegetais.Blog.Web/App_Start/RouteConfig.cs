using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vegetais.Blog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Blog",    // Route name
                "blog/{nomeArtigo}",// URL with parameters
                new
                {
                    controller = "Artigo",
                    action = "Index",
                    nomeArtigo = ""
                },
                namespaces: new[] { "Vegetais.Blog.Web.Controllers" }
            );

            routes.MapRoute(
                "BlogCategorias",    // Route name
                "blog/categoria/{nomeCategoria}",// URL with parameters
                new
                {
                    controller = "Artigo",
                    action = "Categoria",
                    nomeCategoria = ""
                },
                namespaces: new[] { "Vegetais.Blog.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Vegetais.Blog.Web.Controllers" }

            );

        }
    }
}
