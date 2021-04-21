using PeopleDDD.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleDDD.Application.Interfaces
{
    public interface IPeopleAppService
    {
        Task<IEnumerable<PeopleViewModel>> GetAll();
    }
}