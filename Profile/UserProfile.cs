using AutoMapper;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Model;

namespace PhyndDemo_v2.Services{

    public class UserProfile : Profile{

        public UserProfile()
        {
            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();
        }
    }
}