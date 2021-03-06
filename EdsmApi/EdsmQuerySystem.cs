using EdsmApi.Interface;
using EdsmApi.Models;
using System.Runtime.Serialization;

namespace EdsmApi
{
    /// <summary>
    /// Get information about a system - https://www.edsm.net/en/api-v1
    /// </summary>
    public class EdsmQuerySystem : EdsmQueryApiV1, IEdsmQuery<EdsmSystem>
    {
        private static string[] _querySegment = { QueryStrings.system };

        public EdsmQuerySystem()
            : base(_querySegment)
        {
        }
    }

    public partial class QueryStrings
    {
        public const string system = "system";
    }
}
