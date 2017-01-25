using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vegetais.Blog.Web.Models
{
    public class PageBaseViewModel
    {
        public IList<ArtigoViewModel> MateriasMaisVista { get; set; }
    }
}