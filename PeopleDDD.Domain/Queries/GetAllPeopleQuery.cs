using MediatR;
using PeopleDDD.Domain.Models;
using System.Collections.Generic;

namespace PeopleDDD.Domain.Queries
{
    public class GetAllPeopleQuery : IRequest<IEnumerable<People>>
    {

    }
}
