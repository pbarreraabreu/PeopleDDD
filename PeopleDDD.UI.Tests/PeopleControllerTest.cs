using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PeopleDDD.UI.Tests
{   
    public class PeopleControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;        
      
        public PeopleControllerTest(WebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();            
        }

        [Theory]
        [InlineData("/people")]        
        public async Task Get_EndpointsReturnSuccess(string url)
        {
            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }        
    }
}
