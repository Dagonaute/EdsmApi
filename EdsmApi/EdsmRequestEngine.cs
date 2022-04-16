using EdsmApi.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EdsmApi
{
    /// <summary>
    /// The EDSM API request engine use a <see cref="IEdsmQuery{TModels}"/> to retrieve a TModel.
    /// </summary>
    public class EdsmRequestEngine : IEdsmRequestEngine
    {
        #region fields
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _serializerSettings;
        private Stopwatch _lastQueryTimestamp;
        private TimeSpan _queryThrottleMin;
        private TimeSpan _queryThrottle;
        #endregion fields

        #region ctor
        public EdsmRequestEngine(ILogger<EdsmRequestEngine> logger)
        {
            _logger = logger;
            _serializerSettings = new JsonSerializerSettings { Culture = System.Globalization.CultureInfo.InvariantCulture };
            _lastQueryTimestamp = Stopwatch.StartNew();
#warning TODO : Use application settings
            _queryThrottleMin = TimeSpan.FromMilliseconds(100);
            _queryThrottle = TimeSpan.FromMilliseconds(500);
        }
        #endregion ctor

        #region IEdsmRequestEngine
        public TModel Get<TModel>(IEdsmQuery<TModel> query)
            where TModel : new()
        {
            try
            {
                // throttle requests sent to EDSM
                var delay = _queryThrottle.Subtract(_lastQueryTimestamp.Elapsed);
                if (delay < _queryThrottleMin)
                    delay = _queryThrottleMin;
                if (delay > TimeSpan.Zero)
                    Task.Delay(delay).Wait();

                _logger.Log(LogLevel.Trace, "Sending query");
#warning TODO : replace with IHttpClientFactory usage
                var request = WebRequest.CreateHttp(query.Url);
                _logger.Log(LogLevel.Trace, query.Url);
                var response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    _logger.Log(LogLevel.Error, $"Error code {response.StatusCode}: {response.StatusDescription}");
                    return default(TModel);
                }

                _logger.Log(LogLevel.Trace, "Received response");
                var json = ReaderStream(response.GetResponseStream());
                _logger.Log(LogLevel.Trace, json);
                return JsonConvert.DeserializeObject<TModel>(json, _serializerSettings);
            }
            finally
            {
                _lastQueryTimestamp.Restart();
            }
        }
        #endregion IEdsmRequestEngine

        #region methods
        private string ReaderStream(Stream stream)
        {
            using (stream)
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
        #endregion methods
    }
}
