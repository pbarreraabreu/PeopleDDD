using MediatR;
using PeopleDDD.Domain.Models;
using System.Collections.Generic;

namespace PeopleDDD.Domain.Queries
{
    public class GetByIdPeopleQuery : IRequest<People>
    {
        public int Id { get; set; }

        public GetByIdPeopleQuery(int id)
        {
            Id = id;
        }
    }
}
