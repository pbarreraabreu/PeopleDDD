using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeopleDDD.Domain.Models;
using PeopleDDD.Infra.Data.Context;
using PeopleDDD.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PeopleDDD.Infra.Data.Tests.Repository
{
    public class PeopleRepositoryTest : BaseTest
    {
        People people;
        PeopleRepository peopleRepository;
        public PeopleRepositoryTest() : base()
        {
            people = new People
            {
                Name = "Maria",
                Phone = "674547485",
                Surname = "Garcia",
                Dni = "31748541L"
            };
            peopleRepository = new PeopleRepository(dbContext);
        }

        [Fact]
        public async Task CrudTest()
        {
            await Create();
            await FindBy();
            await GetAll();
            await Remove();
        }

        public async Task Create()
        {
            //act
            await peopleRepository.Add(people);

            //assert
            Assert.True(people.ID > 0);
        }

        public async Task FindBy()
        {
            //act
            var query = await peopleRepository.FindBy(p => p.ID == people.ID);
            People result = query.SingleOrDefault();

            //assert
            Assert.NotNull(result);
            Assert.Equal(people.ID, result.ID);
            Assert.Equal(people.Name, result.Name);
            Assert.Equal(people.Surname, result.Surname);
            Assert.Equal(people.Dni, result.Dni);
            Assert.Equal(people.Phone, result.Phone);
        }

        public async Task GetAll()
        {
            //arrange
            await peopleRepository.Add(new People
            {
                Name = "Carlos",
                Phone = "6546545454",
                Surname = "Garcia",
                Dni = "31723423L"
            });

            //act
            IEnumerable<People> result = await peopleRepository.GetAll();

            //assert
            Assert.Equal(2, result.Count());
        }

        public async Task Remove()
        {
            //arrange
            var query = await peopleRepository.FindBy(p => p.ID == people.ID);
            People result = query.SingleOrDefault();

            //act
            await peopleRepository.Remove(result);
            IEnumerable<People> results = await peopleRepository.GetAll();

            //assert
            Assert.Equal(1, results.Count());
        }
    }
}
