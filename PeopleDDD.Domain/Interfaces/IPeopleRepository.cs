using PeopleDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PeopleDDD.Domain.Interfaces
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAll();
        Task Add(People people);        
        Task<IEnumerable<People>> FindBy(Expression<Func<People, bool>> predicate);        
        Task Update(People people);
        Task Remove(People people);
    }
}