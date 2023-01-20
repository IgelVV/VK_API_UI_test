using Aquality.Selenium.Core.Elements.Interfaces;
using L2Veshkin5.Constants;

namespace L2Veshkin5.Extetions
{
    public static class IElementExtention
    {
        public static string GetHref(this IElement element)
        {
            return element.GetAttribute(HtmlAttributes.HREF);
        }
    }
}
