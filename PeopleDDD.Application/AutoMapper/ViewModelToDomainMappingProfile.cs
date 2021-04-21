using AutoMapper;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.Domain.Commands;
using PeopleDDD.Domain.Models;

namespace PeopleDDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PeopleViewModel, CreatePeopleCommand>()
               .ConstructUsing(c => new CreatePeopleCommand(c.Name, c.Surname, c.Dni, c.Phone));
            CreateMap<PeopleViewModel, UpdatePeopleCommand>()
               .ConstructUsing(c => new UpdatePeopleCommand(c.Id, c.Name, c.Surname, c.Dni, c.Phone));
        }
    }
}
