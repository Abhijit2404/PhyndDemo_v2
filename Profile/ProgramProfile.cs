using AutoMapper;
using PhyndDemo_v2.DTOs;

namespace PhyndDemo_v2.Services{

    public class ProgramProfile : Profile{

        public ProgramProfile()
        {
            CreateMap<Model.Program,ProgramDto>();
            CreateMap<Model.Program,ProgramToCreateDto>();
            CreateMap<ProgramToCreateDto,Model.Program>();
        }
    }
}