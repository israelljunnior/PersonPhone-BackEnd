using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<PersonPhone> FindByIdAsync(string phoneNumber);
        Task<PersonPhone> SaveAsync(PersonPhone personPhone);
        void Delete(PersonPhone personPhone);
    }
}
