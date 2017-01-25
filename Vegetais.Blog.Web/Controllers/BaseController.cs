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
            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
        }
    }
}