using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegetais.Blog.Infrastructure.Data;
using Vegetais.Blog.Web.Models;

namespace Vegetais.Blog.Web.Controllers
{
    public class BaseController : Controller
    {
        public MainLayoutViewModel MainLayoutViewModel { get; set; }

        public BaseController()
        {
            this.MainLayoutViewModel = new MainLayoutViewModel();

            var db = new BlogModelContainer();

            var rnd = (new Random()).NextDouble();

            var artigos = db.ArtigoSet
                .OrderBy(x => SqlFunctions.Checksum(x.Id * rnd))
                .ToList()
                .Select(x => new ArtigoViewModel(x.Titulo, x.Conteudo, x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor, x.DataDePublicacao))
                .ToList();

            this.MainLayoutViewModel.MateriasMaisVista = artigos;

            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
        }
    }
}