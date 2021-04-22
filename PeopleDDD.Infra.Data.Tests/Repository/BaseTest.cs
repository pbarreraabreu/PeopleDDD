using Microsoft.EntityFrameworkCore;
using PeopleDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDDD.Infra.Data.Tests.Repository
{
    public class BaseTest
    {
        protected PeopleDDDContext dbContext;

        public BaseTest()
        {
            dbContext = CreateNewContext();
        }

        protected static PeopleDDDContext CreateNewContext()
        {
            var options = new DbContextOptionsBuilder<PeopleDDDContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var context = new PeopleDDDContext(options);

            return context;
        }
    }
}
