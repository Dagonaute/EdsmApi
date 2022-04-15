using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EdsmApi
{
    public static class WebExtensions
    {
        public static string ElementToString(KeyValuePair<string, object> element)
        {
            return string.Join('=', element.Key, WebUtility.UrlEncode($"{element.Value}"));
        }


        public static StringBuilder AppendQuery(this StringBuilder result, IEnumerable<KeyValuePair<string, object>> elements)
        {
            var formattedElements = elements
                .Where(o => o.Value != null)
                .Select(ElementToString);

            if (formattedElements.Any())
                result.Append('?').AppendJoin('&', formattedElements);

            return result;
        }
    }
}
