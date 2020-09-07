using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace Module1.TypesAndClasses.Tests.API_tests
{
    public class APITest
    {
        public IRestResponse Rest()
        {
            RestClient client = new RestClient("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/quickAnswer?q=How%20much%20vitamin%20c%20is%20in%202%20apples%253F");
            RestRequest request = new RestRequest(Method.GET);

            request.AddHeader("x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "962e5fa17cmsh48863d29471da69p1412f9jsnc0925882ba2d");
            IRestResponse response = client.Execute(request);
            return response;
        }
        static async Task<DataTable> GetInfo()
            {
                // Initialization.  
                DataTable responseObj = new DataTable();

                // HTTP GET.  
                using (var client = new HttpClient())
                {
                    // Setting Base address.  
                    client.BaseAddress = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/quickAnswer?q=How%20much%20vitamin%20c%20is%20in%202%20apples%253F");

                    // Setting content type.  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "962e5fa17cmsh48863d29471da69p1412f9jsnc0925882ba2d");
                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();

                    // HTTP GET  
                    response = await client.GetAsync("api/WebApi").ConfigureAwait(false);

                   // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string result = response.Content.ReadAsStringAsync().Result;
                        responseObj = JsonConvert.DeserializeObject<DataTable>(result);
                    }
                }

                return responseObj;

            }

        [Fact]
        public void testResponseCode()
        {
            var Method1 = GetInfo();
            var Method2 = Rest();
            Assert.NotNull(Method1);
            Assert.NotNull(Method2);
        }
    }
}
