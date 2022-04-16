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
        private static string[] _querySegment = { "system" };

        public EdsmQuerySystem()
            : base(_querySegment)
        {
        }

        [DataMember(Name = EdsmQueryParameterName.showInformation)]
        public bool ShowInformation { get; set; } = true;

        [DataMember(Name = EdsmQueryParameterName.showPermit)]
        public bool ShowPermit { get; set; } = true;
    }
}
