using EdsmApi.Interface;
using EdsmApi.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EdsmApi
{
    /// <summary>
    /// Get systems in a sphere radius - https://www.edsm.net/en/api-v1
    /// </summary>
    public class EdsmQuerySphereSystems : EdsmQueryApiV1, IEdsmQuery<List<EdsmSystem>>
    {
        private static string[] _querySegment = { QueryStrings.sphereSystems };

        public EdsmQuerySphereSystems()
            : base(_querySegment)
        {
        }

        /// <summary>
        /// The desired radius in ly.
        /// Maximum value is 100.
        /// </summary>
        [DataMember(Name = EdsmQueryParameterName.radius)]
        public int Radius { get; set; }
    }

    public partial class QueryStrings
    {
        public const string sphereSystems = "sphere-systems";
    }
}
