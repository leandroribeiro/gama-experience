using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegetais.Blog.Infrastructure;
using Vegetais.Blog.Web.Models;

namespace Vegetais.Blog.Web.Controllers
{
    public class ArtigoController : BaseController
    {
        // GET: Artigo
        public ActionResult Index(string nomeArtigo)
        {
            var db = new BlogModelContainer();

            var permalink = RouteData.Values["nomeArtigo"];
            var model = db.ArtigoSet.First(x => x.Permalink == permalink);
            var viewModel = new ArtigoViewModel(model);

            ArmazenarCookieDeAcesso();

            return View(viewModel);
        }

        private void ArmazenarCookieDeAcesso()
        {
            var identificador = Request.AnonymousID;
            var quantidadeDeAcessos = ObterQuantidadeDeAcessos(Request.AnonymousID) + 1;

            //JavaScriptSerializer().Serialize("teste");

            HttpCookie aCookie = new HttpCookie(identificador);
            aCookie.Values["acessos"] = quantidadeDeAcessos.ToString();
            aCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(aCookie);

            //if (quantidadeDeAcessos >= 2)
            //Response.Cookies[identificador]["acessos"] = quantidadeDeAcessos.ToString();
            //Response.Cookies[identificador].Expires = DateTime.Now.AddYears(1);
        }

        private int ObterQuantidadeDeAcessos(string anonymousId)
        {
            if (Request.Cookies[anonymousId] == null)
                return 0;

            var quantidadeDeAcessos = 0;
            var cookieInfo = Request.Cookies[anonymousId].Values;

            if (cookieInfo["acessos"] != null)
                quantidadeDeAcessos = int.Parse(cookieInfo["acessos"].ToString());

            return quantidadeDeAcessos;
        }

        // GET: Artigo
        public ActionResult Categoria(string nomeCategoria)
        {
            var db = new BlogModelContainer();

            var permalink = RouteData.Values["nomeCategoria"];
            var model = db.ArtigoSet
                .ToList()
                .Where(x => MyHTMLHelper.ConvertoToUrl(x.Categoria) == permalink)
                .OrderByDescending(x => x.DataDePublicacao)
                .Select(
                    x =>
                        new ArtigoViewModel(x.Titulo, x.Conteudo, x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor,
                            x.DataDePublicacao))

                .ToList();

            return View(model);
        }
    }
}