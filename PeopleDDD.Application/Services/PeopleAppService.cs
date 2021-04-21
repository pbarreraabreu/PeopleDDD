using AutoMapper;
using MediatR;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.Domain.Commands;
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
        private readonly IMediator mediator;

        public PeopleAppService(IPeopleRepository peopleRepository, IMapper mapper, IMediator mediator)
        {
            this.peopleRepository = peopleRepository;
            this.mapper = mapper;
            this.mediator = mediator;
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
            var commandRequest = mapper.Map<CreatePeopleCommand>(peopleViewModel);

            await mediator.Send(commandRequest);
        }

        public async Task Update(PeopleViewModel peopleViewModel)
        {
            var commandRequest = mapper.Map<UpdatePeopleCommand>(peopleViewModel);

            await mediator.Send(commandRequest);
        }

        public async Task Remove(int id)
        {
            var commandRequest = new RemovePeopleCommand(id);
            await mediator.Send(commandRequest);
        }
    }
}
