using MediatR;

namespace PeopleDDD.Domain.Commands
{
    public class CreatePeopleCommand : PeopleCommand, IRequest
    {
        public CreatePeopleCommand(string name, string surname, string dni, string phone)
        {
            this.Name = name;
            this.Surname = surname;
            this.Dni = dni;
            this.Phone = phone;
        }
    }
}
