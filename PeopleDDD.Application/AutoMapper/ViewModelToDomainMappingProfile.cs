using AutoMapper;
using PeopleDDD.Application.ViewModels;
using PeopleDDD.Domain.Models;

namespace PeopleDDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PeopleViewModel, People>();
        }
    }
}
