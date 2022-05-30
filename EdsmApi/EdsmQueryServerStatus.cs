namespace EdsmApi
{
    /// <summary>
    /// Query to api-status-v1
    /// https://www.edsm.net/en/api-status-v1
    /// </summary>
    public class EdsmQueryServerStatus : EdsmQuery
    {
        #region fields
        private static string[] querySegment = { QueryStrings.apiStatusV1, QueryStrings.eliteServer };
        #endregion fields

        #region ctor
        /// <summary>
        /// Initialize a new <see cref="EdsmQueryServerStatus"/> instance.
        /// </summary>
        public EdsmQueryServerStatus()
            : base(querySegment)
        {
        }
        #endregion ctor
    }

    /// <summary>
    /// Elements for the query string.
    /// </summary>
    public partial class QueryStrings
    {
        /// <summary>
        /// Element to status API.
        /// </summary>
        public const string apiStatusV1 = "api-status-v1";

        /// <summary>
        /// Element to Elite server.
        /// </summary>
        public const string eliteServer = "elite-server";
    }
}
