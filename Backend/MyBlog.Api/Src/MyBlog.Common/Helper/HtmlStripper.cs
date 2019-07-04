using System.Text.RegularExpressions;

namespace MyBlog.Common.Helper
{
    public static class HtmlStripper
    {
        public static string StripHTML(string htmlText)
        {
            return Regex.Replace(htmlText, "<.*?>", string.Empty);
        }
    }
}
