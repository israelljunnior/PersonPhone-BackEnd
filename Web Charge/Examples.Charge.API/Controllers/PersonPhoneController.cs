using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request.Person;
using Examples.Charge.Application.Messages.Response;

namespace Examples.Charge.API.Controllers
{
    [Route("api/person/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get([FromBody] PersonPhoneRequest request) => Response(await _facade.FindByIdAsync(request));

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhoneListResponse>> GetAllPhonesByBusinessID([FromBody] PersonPhoneRequest request) => Response(await _facade.FindByIdAsync(request));

        [HttpPost]
        public async Task<ActionResult<PersonPhoneResponse>> Post([FromBody] PersonPhoneRequest request)
        {
            return Response(await _facade.SaveAsync(request));
        }

        [HttpDelete]
        public async Task<ActionResult<PersonPhoneResponse>> Delete([FromBody] PersonPhoneRequest request)
        {
            return Response(await _facade.Delete(request));
        }
    }
}
