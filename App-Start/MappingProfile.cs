using AutoMapper;
using ITS_Technical_Test.Core.Contracts;
using ITS_Technical_Test.Core.Data.Entity.Implementations;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Customer, CustomerContract>().ReverseMap();
            CreateMap<CustomerModel, CustomerContract>().ReverseMap();

        }
    }
}
