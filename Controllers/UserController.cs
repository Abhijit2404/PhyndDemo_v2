using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Helpers;
using PhyndDemo_v2.Model;
using PhyndDemo_v2.Services;
using System.Collections.Generic;

namespace PhyndDemo_v2.Controllers
{
    [Authorize]
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            var usersfromRepo = _userRepository.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersfromRepo));
        }

        [HttpGet("{Id}", Name = "GetUser")] 
        public IActionResult Get(int Id)
        {
            var userfromRepo = _userRepository.GetUser(Id);

            if (userfromRepo == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<UserDto>(userfromRepo));
        }

        [HttpPost]
        public ActionResult<UserToCreateDto> Post(UserToCreateDto user)
        {
            if(_userRepository.CheckEmail(user.Email))
            {
                 return StatusCode(409, $"User with this Email already exists.");
            }

            var createUser = _mapper.Map<User>(user);
            _userRepository.AddUser(createUser);
            _userRepository.Save();

            var userReturn  = _mapper.Map<UserToCreateDto>(createUser);
            return CreatedAtRoute("GetUser",new{Id = userReturn.Id},userReturn);
        }

        [HttpDelete]
        public ActionResult Delete(int Id){

            var userfromRepo = _userRepository.GetUser(Id);
            if (userfromRepo == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(userfromRepo);

            _userRepository.Save();
            return Ok("Deleted Successfully");
        }

        [HttpPatch]
        public ActionResult Patch(int Id, UserToUpdateDto user){
            var userfromRepo = _userRepository.GetUser(Id);
            _mapper.Map(user,userfromRepo);
            _userRepository.UpdateUser(userfromRepo);
            _userRepository.Save();
            return Ok("Updated Successfully");
        }

        [HttpGet("func")]
        public ActionResult<IEnumerable<UserDto>> GetUsers([FromQuery] Params userParams){
            var userfromRepo = _userRepository.GetUsers(userParams);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userfromRepo));
        }
    }
}
