using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        Task<PersonPhone> FindByIdAsync(string PhoneNumber);
        Task<PersonPhone> SaveAsync(PersonPhone personPhone);
        void Delete(PersonPhone personPhone);
    }
}
