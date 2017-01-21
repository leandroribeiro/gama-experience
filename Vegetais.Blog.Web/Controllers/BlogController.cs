using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vegetais.Blog.Web.Controllers
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

    public class BlogController : Controller
    {

        // GET: Blog
        public ActionResult Index()
        {
            var posts = ObtemOsPostsDoBancoDeDados();

            return View(posts);
        }

        private List<PostViewModel> ObtemOsPostsDoBancoDeDados()
        {
            var posts = new List<PostViewModel>
            {
                new PostViewModel(
                    "Lançamento do nosso portal", 
                    "https://netshow.me/blog/wp-content/uploads/2016/12/flash-media-live-encoder.jpg", 
                    "", 
                    "https://netshow.me/blog/adobe-flash-media-live-encoder-passo-a-passo-para-configurar/"),

                new PostViewModel(
                    "Primeiro milhao de clientes", 
                    "https://netshow.me/blog/wp-content/uploads/2016/10/his-2016.jpg", 
                    "", 
                    "https://netshow.me/blog/his-2016-transmissoes-ao-vivo/"),

                new PostViewModel(
                    "Aprenda como a fazer seu vídeo", 
                    "https://netshow.me/blog/wp-content/uploads/2016/10/Sebrae-1000x669.jpg", 
                    "", 
                    "https://netshow.me/blog/sebrae-transmissoes-ao-vivo/"),

                new PostViewModel(
                    "Aprenda como a fazer seu logo",
                    "",
                    "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/msV1MRcU5Kw\" frameborder=\"0\" allowfullscreen></iframe>", 
                    "")
                               
            };

            return posts;
        }
    }
}