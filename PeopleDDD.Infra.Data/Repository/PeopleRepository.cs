using PeopleDDD.Domain.Interfaces;
using PeopleDDD.Domain.Models;
using PeopleDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDDD.Infra.Data.Repository
{
    public class PeopleRepository : BaseRepositorio<People>, IPeopleRepository
    {
        public PeopleRepository(PeopleDDDContext context): base(context)
        {
        }

       /* public async Task<IEnumerable<People>> GetAll()
        {
            var t = Task.Run<IEnumerable<People>>(() =>
            {
                var peoples = new List<People>();
                peoples.Add(new People { Name = "Pedro", Dni = "sadf", Phone = "555" });
                peoples.Add(new People { Name = "Pedro", Dni = "sadf", Phone = "555" });
                peoples.Add(new People { Name = "Pedro", Dni = "sadf", Phone = "555" });

                return peoples;
            });

            return await t;
        }*/
    }
}
