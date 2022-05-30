using EdsmApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace EdsmApi
{
    /// <summary>
    /// Base query to EDSM.
    /// </summary>
    public abstract class EdsmQuery : IEdsmQuery
    {
        #region fields
        private static string[] _edsmUrl = { QueryStrings.edsmDomain };
        private string _urlBase;
        #endregion fields

        #region ctor
        protected EdsmQuery(IEnumerable<string> segments)
        {
            _urlBase = string.Join(QueryStrings.joinSeparator, _edsmUrl.Concat(segments));
        }
        #endregion ctor

        #region IEdsmQuery
        public string Url => BuildUrl();
        #endregion IEdsmQuery

        #region methods
        protected string BuildUrl()
        {
            var parameters = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                .Select(Parameter)
                .Where(o => o != null)
                .Cast<KeyValuePair<string, object>>();

            return new StringBuilder(_urlBase).AppendQuery(parameters).ToString();
        }

        protected KeyValuePair<string, object>? Parameter(PropertyInfo propertyInfo)
        {
            var dataMember = propertyInfo.GetCustomAttribute<DataMemberAttribute>();
            if (dataMember == null)
                return null;

            return new KeyValuePair<string, object>(dataMember.Name, GetValue(propertyInfo));
        }

        protected object GetValue(PropertyInfo propertyInfo)
        {
            var value = propertyInfo.GetValue(this);
            if (value is bool)
                value = Convert.ChangeType(value, typeof(int));

            return value;
        }
        #endregion methods
    }

    /// <summary>
    /// Query to api-v1
    /// https://www.edsm.net/en/api-v1
    /// </summary>
    public abstract class EdsmQueryApiV1 : EdsmQuery
    {
        #region fields
        private static string[] querySegment = { QueryStrings.apiV1 };
        #endregion fields

        #region ctor
        protected EdsmQueryApiV1(IEnumerable<string> segments)
            : base(querySegment.Concat(segments))
        {
        }
        #endregion ctor

        #region properties
        [DataMember(Name = EdsmQueryParameterName.systemName)]
        public string SystemName { get; set; }

        [DataMember(Name = EdsmQueryParameterName.showId)]
        public bool ShowId { get; set; } = true;

        [DataMember(Name = EdsmQueryParameterName.showCoordinates)]
        public bool ShowCoordinates { get; set; } = true;
        #endregion properties
    }

    /// <summary>
    /// Query to api-system-v1
    /// https://www.edsm.net/en/api-system-v1
    /// </summary>
    public abstract class EdsmQueryApiSystemV1 : EdsmQuery
    {
        #region fields
        private static string[] querySegment = { QueryStrings.apiSystemV1 };
        #endregion fields

        #region ctor
        protected EdsmQueryApiSystemV1(IEnumerable<string> segments)
            : base(querySegment.Concat(segments))
        {
        }
        #endregion ctor

        #region properties
        [DataMember(Name = EdsmQueryParameterName.systemName)]
        public string SystemName { get; set; }
        #endregion properties
    }

    public partial class QueryStrings
    {
        public const char joinSeparator = '/';
        public const string edsmDomain = "https://www.edsm.net";
        public const string apiV1 = "api-v1";
        public const string apiSystemV1 = "api-system-v1";
    }

    /// <summary>
    /// Known parameters names for querying the API.
    /// </summary>
    public class EdsmQueryParameterName
    {
        public const string systemName = "systemName";
        public const string showId = "showId";
        public const string radius = "radius";
        public const string showCoordinates = "showCoordinates";
        public const string showInformation = "showInformation";
        public const string showPermit = "showPermit";
        public const string size = "size";
    }
}
