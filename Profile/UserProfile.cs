using AutoMapper;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public class UserProfile : Profile{

        public UserProfile()
        {
            CreateMap<User,UserDto>().ForMember(d => d.Name, d => d.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<User,UserToCreateDto>();
            CreateMap<UserToUpdateDto,User>();
            CreateMap<UserToCreateDto,User>();
            CreateMap<Hospital,HospitalDto>().ForMember(d => d.Address, d => d.MapFrom(src => $"{src.AddressLine1} {","}  {src.AddressLine2}"));
        }
    }
}