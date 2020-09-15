using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Module1.TypesAndClasses.Tests.HttpTests
{
    public class AlexTests
    {

        #region readonly

        static readonly HttpClient client = new HttpClient();

        #endregion

        [Fact]
        public void stateUsaPriceStatus_Test()
        {
            var client = new RestClient("https://gas-price.p.rapidapi.com/stateUsaPrice?state=WA");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "gas-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "30389bb8bcmshf09d018396d98f9p198fc0jsnf56b35618857");
            IRestResponse response = client.Execute(request);

            Assert.True(response.StatusCode.ToString().Equals("OK"), "Status Code is 'OK'");
        }

        [Fact]
        public void stateUsaPrice_Test()
        {
            var client = new RestClient("https://gas-price.p.rapidapi.com/stateUsaPrice?state=WA");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "gas-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "30389bb8bcmshf09d018396d98f9p198fc0jsnf56b35618857");
            IRestResponse response = client.Execute(request);

            Assert.Contains("usd", response.Content);
        }

        [Fact]
        public void stateUsaCurrency_Test()
        {
            var client = new RestClient("https://gas-price.p.rapidapi.com/stateUsaPrice?state=WA");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "gas-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "30389bb8bcmshf09d018396d98f9p198fc0jsnf56b35618857");
            IRestResponse response = client.Execute(request);

            Assert.Contains("currency", response.Content);
        }

        [Fact]
        public async void HttpClient()
        {

            HttpResponseMessage response = await client.GetAsync("http://www.google.com/");

            Assert.True(response.StatusCode.ToString().Equals("OK"), "Status Code is 'OK'");
        }
    }
}
