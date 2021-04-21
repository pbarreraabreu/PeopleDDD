using MediatR;

namespace PeopleDDD.Domain.Commands
{
    public class RemovePeopleCommand : PeopleCommand, IRequest
    {
        public RemovePeopleCommand(int id)
        {
            this.Id = id;            
        }
    }
}
