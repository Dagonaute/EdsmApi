using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EdsmApi
{
    /// <summary>
    /// Helper methods 
    /// </summary>
    public static class WebExtensions
    {
        #region private
        /// <summary>
        /// Store the method used as a query string parameters generator for the application lifetime.
        /// </summary>
        private static Lazy<Func<IEnumerable<KeyValuePair<string, object>>, IEnumerable<string>>> _queryParameters;

        static WebExtensions()
        {
            _queryParameters = new Lazy<Func<IEnumerable<KeyValuePair<string, object>>, IEnumerable<string>>>(QueryParametersProvider);
        }

        /// <summary>
        /// Return a method to build query parameters.
        /// </summary>
        /// <returns>A method instance.</returns>
        private static Func<IEnumerable<KeyValuePair<string, object>>, IEnumerable<string>> QueryParametersProvider()
        {
            // check if we are in a unit test instance
            if (AppDomain.CurrentDomain.GetAssemblies().Any(o => o.FullName.StartsWith("xunit.core")))
            {
                return elements => elements
                    .Where(o => o.Value != null)
                    .OrderBy(o => o.Key) // include parameters sorting to ease validate unit testing result
                    .Select(QueryParameter);
            }

            return elements => elements
                .Where(o => o.Value != null)
                .Select(QueryParameter);
        }
        #endregion private

        #region public
        /// <summary>
        /// Generate a query parameter from a <see cref="KeyValuePair{TKey, TValue}"/>.
        /// </summary>
        /// <param name="element">A <see cref="KeyValuePair{TKey, TValue}"/> instance.</param>
        /// <returns>A formatted string containing key and value joined by equal symbol.</returns>
        public static string QueryParameter(KeyValuePair<string, object> element)
        {
            return string.Join('=', element.Key, WebUtility.UrlEncode($"{element.Value}"));
        }

        /// <summary>
        /// Append all <paramref name="elements"/> as query parameters to the <paramref name="source"/>.
        /// </summary>
        /// <param name="source">A <see cref="StringBuilder"/> instance.</param>
        /// <param name="elements">A <see cref="IEnumerable{T}"/> instance with all elements.</param>
        /// <returns>The <paramref name="source"/> instance to allow chaining calls.</returns>
        public static StringBuilder AppendQuery(this StringBuilder source, IEnumerable<KeyValuePair<string, object>> elements)
        {
            var formattedElements = _queryParameters.Value(elements);

            if (formattedElements.Any())
                source.Append('?').AppendJoin('&', formattedElements);

            return source;
        }
        #endregion public
    }
}
