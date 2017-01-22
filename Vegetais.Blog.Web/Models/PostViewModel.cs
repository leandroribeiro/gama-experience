namespace Vegetais.Blog.Web.Models
{
    public class PostViewModel
    {
        public PostViewModel(string titulo, string imagem, string video, string link)
        {
            this.Titulo = titulo;
            this.Imagem = imagem;
            this.Video = video;
            this.Link = link;
        }

        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Video { get; set; }

        public string Link { get; set; }
    }
}