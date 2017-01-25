using System;
using System.Web;
using System.Web.Mvc;
using Vegetais.Blog.Infrastructure;

namespace Vegetais.Blog.Web.Models
{
    public class ArtigoViewModel
    {
        public ArtigoViewModel(Artigo model) : this(model.Titulo, model.Conteudo, model.Imagem, model.Video, model.Permalink, model.Categoria, model.Autor, model.DataDePublicacao)
        {

        }

        public ArtigoViewModel(string titulo, string conteudo, string imagem, string video, string link, string categoria, string autor, DateTime dataDePublicacao)
        {
            this.Titulo = titulo;
            this.Conteudo = conteudo;
            this.Imagem = imagem;
            this.Video = video;
            this.Link = link;
            this.Categoria = categoria;
            this.CategoriaLink = MyHTMLHelper.ConvertoToUrl(categoria);
            this.Autor = autor;
            this.DataDePublicacao = dataDePublicacao.ToShortDateString();
        }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string ConteudoResumo
        {
            get
            {
                //var permalink = "<a>Ir para</a>";

                //if (Conteudo.Length > 400)
                //    return String.Format("{0} ... {1}", Conteudo.Substring(0, 400), permalink);

                return Conteudo;
            }
        }
        public string Imagem { get; set; }

        public string Video { get; set; }

        public string Link { get; set; }

        public string Categoria { get; set; }

        public string Autor { get; set; }

        public string DataDePublicacao { get; set; }
        public string CategoriaLink { get; private set; }
    }
}