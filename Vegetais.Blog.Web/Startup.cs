﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vegetais.Blog.Web.Startup))]
namespace Vegetais.Blog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
