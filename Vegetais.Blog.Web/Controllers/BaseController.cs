using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            var artigos = db.ArtigoSet
                .ToList()
                //.Select(x => new ArtigoViewModel(x.Titulo, String.Format("{0} {1}", x.Conteudo.Substring(0, 800), "..."), x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor, x.DataDePublicacao))
                .Select(x => new ArtigoViewModel(x.Titulo, x.Conteudo, x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor, x.DataDePublicacao))
                .OrderByDescending(x => x.DataDePublicacao)
                .ToList();

            this.MainLayoutViewModel.MateriasMaisVista = artigos;

            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
        }
    }
}