using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetais.Blog.Infrastructure
{
    public static class MyHTMLHelper
    {
        public static string ConvertoToUrl(string value)
        {
            return value.ToLower().Replace(" ", "-");
        }
    }
}
