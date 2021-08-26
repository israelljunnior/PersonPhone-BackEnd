using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person.Include(x => x.Phones).ToListAsync());
        public async Task<Person> FindByIdAsync(int businessEntityID) => await Task.Run(() => _context.Person.Include(x => x.Phones).FirstOrDefaultAsync(x => x.BusinessEntityID == businessEntityID));
        public async Task<Person> SaveAsync(Person person)
        {
            await Task.Run(() => {
                _context.Person.Add(person);
                _context.SaveChangesAsync();
            });

            return person;
        }
    }
}
