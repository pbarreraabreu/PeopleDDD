using PeopleDDD.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleDDD.Domain.Interfaces
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAll();
    }
}