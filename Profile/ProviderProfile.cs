using AutoMapper;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public class ProviderProfile : Profile{

        public ProviderProfile()
        {
            CreateMap<Provider,ProviderDto>().ForMember(d => d.Name, d => d.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"));
            CreateMap<Provider,ProviderToCreateDto>();
            CreateMap<ProviderToCreateDto,Provider>();
        }
    }
}