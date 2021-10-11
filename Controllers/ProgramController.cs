using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Services;

namespace PhyndDemo_v2.Controllers
{
    [Authorize]
    [Route("programs")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;
        public ProgramController(IProgramRepository programRepository,IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProgramDto>> Get()
        {
            var programsfromRepo = _programRepository.GetPrograms();
            return Ok(_mapper.Map<IEnumerable<ProgramDto>>(programsfromRepo));
        }

        [HttpGet("{Id}", Name = "GetProgram")] 
        public IActionResult Get(int Id)
        {
            var programfromRepo = _programRepository.GetProgram(Id);

            if (programfromRepo == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ProgramDto>(programfromRepo));
        }

        [HttpPost]
        public ActionResult<ProgramToCreateDto> Post(ProgramToCreateDto Program)
        {
            var createProgram = _mapper.Map<Model.Program>(Program);
            _programRepository.AddProgram(createProgram);
            _programRepository.Save();

            var ProgramReturn  = _mapper.Map<ProgramToCreateDto>(createProgram);
            return CreatedAtRoute("GetProgram",new{Id = ProgramReturn.Id},ProgramReturn);
        }

        [HttpDelete]
        public ActionResult Delete(int Id){

            var ProgramfromRepo = _programRepository.GetProgram(Id);
            if (ProgramfromRepo == null)
            {
                return NotFound();
            }

            _programRepository.DeleteProgram(ProgramfromRepo);

            _programRepository.Save();

            return Ok("Deleted Successfully");
        }

        [HttpGet("func")]
        public ActionResult<IEnumerable<ProgramDto>> GetPrograms([FromQuery] programParams programParams){
            var programfromRepo = _programRepository.GetPrograms(programParams);
            return Ok(_mapper.Map<IEnumerable<ProgramDto>>(programfromRepo));
        }
    }
}