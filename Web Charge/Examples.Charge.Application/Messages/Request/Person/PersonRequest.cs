using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        public int BusinessEntityID { get; set; }
        public string Name { get; set; }
        public ICollection<PersonPhone> Phones { get; set; }
    }
}
