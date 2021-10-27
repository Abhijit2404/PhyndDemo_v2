using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Services;

namespace PhyndDemo_v2.Controllers
{
    [Authorize]
    [Route("hospital")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public HospitalController(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<HospitalDto>> GetHospital()
        {
            var hospitalsfromRepo = _userRepository.GetHospitals();
            return Ok(_mapper.Map<IEnumerable<HospitalDto>>(hospitalsfromRepo));
        }
    }
}