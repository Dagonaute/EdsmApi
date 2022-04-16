using EdsmApi.Interface;
using EdsmApi.Models;

namespace EdsmApi
{
    /// <summary>
    /// Get information about celestial bodies in a system - https://www.edsm.net/en/api-system-v1
    /// </summary>
    public class EdsmQueryBodies : EdsmQueryApiSystemV1, IEdsmQuery<EdsmSystemBodies>
    {
        private static string[] _querySegment = { "bodies" };

        public EdsmQueryBodies()
            : base(_querySegment)
        {
        }
    }
}
