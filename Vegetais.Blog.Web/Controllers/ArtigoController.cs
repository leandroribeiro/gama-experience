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

            return View(viewModel);
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