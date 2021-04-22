using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using PeopleDDD.Application.Services;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.UI;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PeopleDDD.Application.Tests.Services
{
    public class PeopleAppServiceTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;
        private readonly WebApplicationFactory<Startup> factory;

        public PeopleAppServiceTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            this.client = factory.CreateClient();
        }

        [Fact]
        public async Task CrudTest()
        {
            var result = await client.GetAsync("/people/");
            Assert.True(result.IsSuccessStatusCode);
            
        }
    }
}
