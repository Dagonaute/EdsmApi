using EdsmApi;
using System;
using Xunit;

namespace Tests
{
    public class EdsmQuerySystemTests
    {
        [Fact]
        public void EdsmQuerySystemTest1()
        {
            var expectedUrl = "https://www.edsm.net/api-v1/system?showCoordinates=1&showId=1&showInformation=1&showPermit=1";
            var query = new EdsmQuerySystem();
            Assert.Equal(expectedUrl, query.Url);
        }

        [Fact]
        public void EdsmQuerySystemTest2()
        {
            var expectedUrl = ExpectedQueryUrl("api-v1/system",
                "showCoordinates=1&showId=0&showInformation=0&showPermit=0&systemName=WISE+1506%2B7027");
            var query = new EdsmQuerySystem();
            query.SystemName = "WISE 1506+7027";
            query.ShowPermit = false;
            query.ShowInformation = false;
            query.ShowId = false;
            Assert.Equal(expectedUrl, query.Url);
        }

        protected string ExpectedQueryUrl(string apiPath, string query)
        {
            return string.Concat(QueryStrings.edsmDomain, QueryStrings.joinSeparator, apiPath, '?', query);
        }
    }
}
