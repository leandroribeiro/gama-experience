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
                .Select(x => new ArtigoViewModel(x.Titulo, x.Imagem, x.Video, ""))
                .ToList();

            return View(artigos);
        }

    }
}