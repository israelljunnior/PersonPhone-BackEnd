using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }
        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();
        public async Task<PersonPhone> FindByIdAsync(string phoneNumber) => (await _personPhoneRepository.FindByIdAsync(phoneNumber));
        public async Task<PersonPhone> SaveAsync(PersonPhone phone) => (await _personPhoneRepository.SaveAsync(phone));
        public void Delete(PersonPhone phone) 
        {
            _personPhoneRepository.Delete(phone);
        }
    }
}
