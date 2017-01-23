using System;
using Vegetais.Blog.Infrastructure;

namespace Vegetais.Blog.Web.Models
{
    public class ArtigoViewModel
    {
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

        public string Imagem { get; set; }

        public string Video { get; set; }

        public string Link { get; set; }

        public string Categoria { get; set; }

        public string Autor { get; set; }

        public string DataDePublicacao { get; set; }
        public string CategoriaLink { get; private set; }
    }
}