using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vegetais.Blog.Infrastructure;
using Vegetais.Blog.Web.Models;

namespace Vegetais.Blog.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
            var db = new BlogModelContainer();

            var artigos = db.ArtigoSet
                .OrderByDescending(x => x.DataDePublicacao)
                .ToList()
                .Select(
                    x =>
                        new ArtigoViewModel(x.Titulo, x.Conteudo, x.Imagem, x.Video, x.Permalink, x.Categoria, x.Autor,
                            x.DataDePublicacao))
                .ToList();

            return View(artigos);
        }

        [HttpPost]
        public ActionResult Enviar(string nome, string email)
        {
            var db = new BlogModelContainer();
            var associado = new Associado()
            {
                Email = email,
                HoraCadastro = DateTime.Now,
                IP = MyRequestHelper.GetIPAdress(Request),
                Nome = nome
            };
            
            db.AssociadoSet.Add(associado);
            db.SaveChanges();

            ArmazenarCookie(nome, email);

            return View("Obrigado");
        }

        private void ArmazenarCookie(string nome, string email)
        {
            var identificador = Request.AnonymousID;
            Response.Cookies[identificador]["nome"] = nome;
            Response.Cookies[identificador]["email"] = email;
            Response.Cookies[identificador].Expires = DateTime.Now.AddYears(1);
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