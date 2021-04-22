using MediatR;
using PeopleDDD.Domain.Interfaces;
using PeopleDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleDDD.Domain.Queries
{
    public class PeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, IEnumerable<People>>,
                                      IRequestHandler<GetByIdPeopleQuery, People>
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleQueryHandler(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        public async Task<IEnumerable<People>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<People> result = await peopleRepository.GetAll();

            return result;
        }

        public async Task<People> Handle(GetByIdPeopleQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<People> result = await peopleRepository.FindBy(e => e.ID == request.Id);

            return result.FirstOrDefault();
        }
    }
}
