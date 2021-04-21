using AutoMapper;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.Domain.Interfaces;
using PeopleDDD.Domain.Models;
using System;
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

        public async Task<PeopleViewModel> GetById(int id)
        {
            IEnumerable<People> result = await peopleRepository.FindBy(e => e.ID == id);

            return mapper.Map<PeopleViewModel>(result.FirstOrDefault());
        }

        public async Task Register(PeopleViewModel peopleViewModel)
        {
            People model = mapper.Map<People>(peopleViewModel);
            await peopleRepository.Add(model);
        }

        public async Task Update(PeopleViewModel peopleViewModel)
        {
            People model = mapper.Map<People>(peopleViewModel);
            await peopleRepository.Update(model);
        }

        public async Task Remove(int id)
        {
            var result = await peopleRepository.FindBy(e => e.ID == id);
            People model = result.FirstOrDefault();
            if (model == null)
                throw new Exception("User not found");

            await peopleRepository.Remove(model);
        }
    }
}
