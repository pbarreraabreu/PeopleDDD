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
    }
}
