using MediatR;

namespace PeopleDDD.Domain.Commands
{
    public class UpdatePeopleCommand : PeopleCommand, IRequest
    {
        public UpdatePeopleCommand(int id, string name, string surname, string dni, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Dni = dni;
            this.Phone = phone;
        }
    }
}
