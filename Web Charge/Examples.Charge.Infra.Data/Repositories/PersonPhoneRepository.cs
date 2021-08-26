using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);

        public async Task<PersonPhone> FindByIdAsync(string PhoneNumber) => await Task
                .Run(() =>_context.PersonPhone.Include(x => x.PhoneNumberType).FirstOrDefault(x => x.PhoneNumber == PhoneNumber ));

        public async Task<PersonPhone> SaveAsync(PersonPhone personPhone)
        {
           await Task.Run(() => {
                _context.PersonPhone.AddAsync(personPhone);
                _context.SaveChangesAsync();
           });

            return personPhone;
        }
        public async void Delete(PersonPhone personPhone)
        {
            await Task.Run(() => {
                _context.PersonPhone.Remove(personPhone);
                _context.SaveChangesAsync();
            });
        }
    }
}
