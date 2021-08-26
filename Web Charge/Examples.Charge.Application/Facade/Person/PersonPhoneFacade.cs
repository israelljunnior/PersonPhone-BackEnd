using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request.Person;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IPersonService personService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            var response = new PersonPhoneListResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }
        public async Task<PersonPhoneResponse> FindByIdAsync(PersonPhoneRequest personPhoneRequest)
        {
            var result = await _personPhoneService.FindByIdAsync(personPhoneRequest.PhoneNumber);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObject = new PersonPhoneDto();
            response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(result);
            return response;
        }
        public async Task<PersonPhoneResponse> SaveAsync(PersonPhoneRequest request)
        {
            var personPhone = _mapper.Map<PersonPhone>(request);
            personPhone.Person = await _personService.FindByIdAsync(request.Id);
            var result = await _personPhoneService.SaveAsync(personPhone);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObject = new PersonPhoneDto();
            response.PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhone);
            return response;
        }
        public async Task<PersonPhoneResponse> Delete(PersonPhoneRequest request)
        {
            var registry = await _personPhoneService.FindByIdAsync(request.PhoneNumber);
            _personPhoneService.Delete(registry);
            var response = new PersonPhoneResponse();
            response.Success = true;
            return response;
        }
    }
}
