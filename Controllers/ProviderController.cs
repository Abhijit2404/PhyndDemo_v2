using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Services;
using PhyndDemo_v2.Model;
using PhyndDemo_v2.Helpers;

namespace PhyndDemo_v2.Controllers
{
    [Authorize]
    [Route("providers")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;
        public ProviderController(IProviderRepository providerRepository,IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProviderDto>> Get()
        {
            var providersfromRepo = _providerRepository.GetProviders();
            return Ok(_mapper.Map<IEnumerable<ProviderDto>>(providersfromRepo));
        }

        [HttpGet("{Id}", Name = "GetProvider")] 
        public IActionResult Get(int Id)
        {
            var providerfromRepo = _providerRepository.GetProvider(Id);

            if (providerfromRepo == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ProviderDto>(providerfromRepo));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ProviderToCreateDto> Post(ProviderToCreateDto Provider)
        {

            if(_providerRepository.CheckProvider(Provider.FirstName,Provider.MiddleName,Provider.LastName))
            {
                 return StatusCode(409, $"Provider already exists.");
            }

            var createProvider = _mapper.Map<Provider>(Provider);
            _providerRepository.AddProvider(createProvider);
            _providerRepository.Save();

            var ProviderReturn  = _mapper.Map<ProviderToCreateDto>(createProvider);
            return CreatedAtRoute("GetProvider",new{Id = ProviderReturn.Id},ProviderReturn);
        }

        [HttpDelete]
        [AllowAnonymous]
        public ActionResult Delete(int Id){

            var ProviderfromRepo = _providerRepository.GetProvider(Id);
            if (ProviderfromRepo == null)
            {
                return NotFound();
            }

            _providerRepository.DeleteProvider(ProviderfromRepo);

            _providerRepository.Save();

            return Ok("Deleted Successfully");
        }

        [HttpGet("func")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ProviderDto>> GetProviders([FromQuery] Params providerParams){
            var providerfromRepo = _providerRepository.GetProviders(providerParams);
            return Ok(_mapper.Map<IEnumerable<ProviderDto>>(providerfromRepo));
        }
    }
}