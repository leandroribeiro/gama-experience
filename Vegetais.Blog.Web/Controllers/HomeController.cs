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

            var posts = db.PostSet
                .ToList()
                .Select(x => new PostViewModel(x.Titulo, x.Imagem, x.Video, x.Link))
                .ToList();

            return View(posts);
        }

    }
}