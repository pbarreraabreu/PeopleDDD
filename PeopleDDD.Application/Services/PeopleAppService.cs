using AutoMapper;
using MediatR;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.Domain.Commands;
using PeopleDDD.Domain.Interfaces;
using PeopleDDD.Domain.Models;
using PeopleDDD.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleDDD.Application.Services
{
    public class PeopleAppService : IPeopleAppService
    {        
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PeopleAppService(IMapper mapper, IMediator mediator)
        {            
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<IEnumerable<PeopleViewModel>> GetAll()
        {
            var commandRequest = new GetAllPeopleQuery();
            var result = await mediator.Send(commandRequest);
            return mapper.Map<IEnumerable<PeopleViewModel>>(result);
        }

        public async Task<PeopleViewModel> GetById(int id)
        {
            var commandRequest = new GetByIdPeopleQuery(id);
            var result = await mediator.Send(commandRequest);
            return mapper.Map<PeopleViewModel>(result);
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
