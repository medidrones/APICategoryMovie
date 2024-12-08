using Microsoft.AspNetCore.Mvc.Testing;

namespace CategoryMovie.Test
{
    public class MoviesTest
    {
        private HttpClient _httpClient;

        public MoviesTest()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task Test1()
        {
            var response = await _httpClient.GetAsync("/Movies");
            var result = await response.Content.ReadAsStringAsync();

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}