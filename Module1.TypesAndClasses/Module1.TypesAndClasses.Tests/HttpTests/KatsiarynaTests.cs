using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Module1.TypesAndClasses.Tests.HttpTests
{
    public class KatsiarynaTests
    {
        [Fact]
        public void RapidAPI_Test()
        {
            var client = new RestClient("https://uphere-space1.p.rapidapi.com/satellite/20580/location?units=imperial&lat=47.6484346&lng=122.374199");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "uphere-space1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "a57c2d6e74msh3274d7fd928c801p146e75jsnd8f743928f17");
            IRestResponse response = client.Execute(request);
            
            Assert.True(response.ResponseUri.Port.Equals(443), "Port was '443'");
        }

        [Fact]
        public async Task HttpClient_Test()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("x-rapidapi-host", "uphere-space1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "a57c2d6e74msh3274d7fd928c801p146e75jsnd8f743928f17");

            HttpResponseMessage response = await client.GetAsync("https://uphere-space1.p.rapidapi.com/satellite/20580/location?units=imperial&lat=47.6484346&lng=122.374199");
            response.EnsureSuccessStatusCode();

            Assert.True(response.StatusCode.ToString().Equals("OK"), "StatusCode was 'OK'");
        }
    }
}
