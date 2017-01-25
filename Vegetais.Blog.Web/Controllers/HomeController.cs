using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegetais.Blog.Web.Models;

namespace Vegetais.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            var db = new BlogModelContainer();

            var artigos = db.ArtigoSet
                .ToList()
                //.Select(x => new ArtigoViewModel(x.Titulo, String.Format("{0} {1}", x.Conteudo.Substring(0, 800), "..."), x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor, x.DataDePublicacao))
                .Select(x => new ArtigoViewModel(x.Titulo, x.Conteudo, x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor, x.DataDePublicacao))
                .OrderByDescending(x=>x.DataDePublicacao)
                .ToList();

            return View(artigos);
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Materiais()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        public ActionResult Transmissao()
        {
            return View();
        }

        public ActionResult Obrigado()
        {
            return View();
        }
        public ActionResult IndicarAmigo()
        {
            return View();
        }
    }


}