namespace Vegetais.Blog.Web.Models
{
    public class ArtigoViewModel
    {
        public ArtigoViewModel(string titulo, string conteudo, string imagem, string video, string link)
        {
            this.Titulo = titulo;
            this.Conteudo = conteudo;
            this.Imagem = imagem;
            this.Video = video;
            this.Link = link;
        }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string Imagem { get; set; }

        public string Video { get; set; }

        public string Link { get; set; }
    }
}