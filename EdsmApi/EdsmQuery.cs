using EdsmApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace EdsmApi
{
    public abstract class EdsmQuery : IEdsmQuery
    {
        #region fields
        private const char _joinSeparator = '/';
        private static string[] _edsmUrl = { "https://www.edsm.net" };
        private string _urlBase;
        #endregion fields

        #region ctor
        protected EdsmQuery(IEnumerable<string> segments)
        {
            _urlBase = string.Join(_joinSeparator, _edsmUrl.Concat(segments));
        }
        #endregion ctor

        #region IEdsmQuery
        public string Url => BuildUrl();
        #endregion IEdsmQuery

        #region properties
        [DataMember(Name = EdsmQueryParameterName.systemName)]
        public string SystemName { get; set; }
        #endregion properties

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

    public abstract class EdsmQueryApiV1 : EdsmQuery
    {
        #region fields
        private static string[] querySegment = { "api-v1" };
        #endregion fields

        #region ctor
        protected EdsmQueryApiV1(IEnumerable<string> segments)
            : base(querySegment.Concat(segments))
        {
        }
        #endregion ctor

        [DataMember(Name = EdsmQueryParameterName.showId)]
        public bool ShowId { get; set; } = true;

        [DataMember(Name = EdsmQueryParameterName.showCoordinates)]
        public bool ShowCoordinates { get; set; } = true;
    }

    public abstract class EdsmQueryApiSystemV1 : EdsmQuery
    {
        #region fields
        private static string[] querySegment = { "api-system-v1" };
        #endregion fields

        #region ctor
        protected EdsmQueryApiSystemV1(IEnumerable<string> segments)
            : base(querySegment.Concat(segments))
        {
        }
        #endregion ctor
    }

    public class EdsmQueryParameterName
    {
        public const string systemName = nameof(systemName);
        public const string showId = nameof(showId);
        public const string radius = nameof(radius);
        public const string showCoordinates = nameof(showCoordinates);
        public const string showInformation = nameof(showInformation);
        public const string showPermit = nameof(showPermit);
        public const string size = nameof(size);
    }
}
