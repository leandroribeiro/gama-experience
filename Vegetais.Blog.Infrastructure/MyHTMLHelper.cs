using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vegetais.Blog.Infrastructure
{
    public static class MyHTMLHelper
    {
        public static string ConvertoToUrl(string text)
        {
            var textValue = text.ToLower().Replace(" ", "-");

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(textValue, "");

            /*
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();

            var textSanitized = new string(chars).Normalize(NormalizationForm.FormC);

            return textSanitized.ToLower().Replace(" ", "-");
            */
        }

    }
}

public static class HtmlHelperExtensions
{
    // Alternative version
    public static string RouteUrl(this HtmlHelper htmlHelper, string routeName, object routeValues)
    {
        return htmlHelper.RouteUrl(routeName, new RouteValueDictionary(routeValues));
    }

    public static MvcHtmlString MyRouteLink(
this HtmlHelper htmlHelper,
string linkText,
string routeName,
RouteValueDictionary routeValues,
IDictionary<string, object> htmlAttributes)
    {
        string url = RouteUrl(htmlHelper, routeName, routeValues);

        TagBuilder tagBuilder = new TagBuilder("a")
        {
            InnerHtml = (!String.IsNullOrEmpty(linkText)) ? linkText : String.Empty
        };

        tagBuilder.MergeAttributes(htmlAttributes);
        tagBuilder.MergeAttribute("href", url);

        return MvcHtmlString.Create((tagBuilder.ToString(TagRenderMode.Normal)));
    }
}
