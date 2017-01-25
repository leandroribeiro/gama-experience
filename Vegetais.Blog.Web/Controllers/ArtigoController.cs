using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}