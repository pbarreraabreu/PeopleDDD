using MediatR;
using PeopleDDD.Domain.Interfaces;
using PeopleDDD.Domain.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleDDD.Domain.Commands
{
    public class PeopleCommandHandler : IRequestHandler<CreatePeopleCommand>, 
                                        IRequestHandler<UpdatePeopleCommand>,
                                        IRequestHandler<RemovePeopleCommand>
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleCommandHandler(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        public async Task<Unit> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            People people = new() { Name = request.Name, Phone = request.Phone, Surname = request.Surname, Dni = request.Dni };

            await peopleRepository.Add(people);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            People people = new() { ID = request.Id, Name = request.Name, Phone = request.Phone, Surname = request.Surname, Dni = request.Dni };

            await peopleRepository.Update(people);

            return Unit.Value;
        }

        public async Task<Unit> Handle(RemovePeopleCommand request, CancellationToken cancellationToken)
        {
            var result = await peopleRepository.FindBy(e => e.ID == request.Id);
            People model = result.FirstOrDefault();
            if (model == null)
                throw new Exception("User not found");

            await peopleRepository.Remove(model);

            return Unit.Value;
        }
    }
}
