using PeopleDDD.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleDDD.Application.Interfaces
{
    public interface IPeopleAppService
    {
        Task<IEnumerable<PeopleViewModel>> GetAll();
        Task Register(PeopleViewModel peopleViewModel);
        Task Update(PeopleViewModel peopleViewModel);
        Task<PeopleViewModel> GetById(int id);
        Task Remove(int id);
    }
}