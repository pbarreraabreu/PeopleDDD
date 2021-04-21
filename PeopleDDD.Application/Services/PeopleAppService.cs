using AutoMapper;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleDDD.Application.Services
{
    public class PeopleAppService : IPeopleAppService
    {
        private readonly IPeopleRepository peopleRepository;
        private readonly IMapper mapper;

        public PeopleAppService(IPeopleRepository peopleRepository, IMapper mapper)
        {
            this.peopleRepository = peopleRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PeopleViewModel>> GetAll()
        {
            return mapper.Map<IEnumerable<PeopleViewModel>>(await peopleRepository.GetAll());
        }
    }
}
