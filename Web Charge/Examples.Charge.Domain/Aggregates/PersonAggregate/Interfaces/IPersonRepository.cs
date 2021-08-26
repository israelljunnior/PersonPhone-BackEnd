using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAllAsync();
        Task<Person> FindByIdAsync(int businessEntityID);
        Task<Person> SaveAsync(Person person);
    }
}
