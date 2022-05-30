using EdsmApi;
using Xunit;

namespace Tests
{
    public class EdsmQueryServerStatusTests
    {
        [Fact]
        public void ServerStatusTest()
        {
            var expectedUrl = "https://www.edsm.net/api-status-v1/elite-server";
            var query = new EdsmQueryServerStatus();
            Assert.Equal(expectedUrl, query.Url);
        }
    }
}
