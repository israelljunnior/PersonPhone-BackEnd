using Examples.Charge.Application.Messages.Request.Person;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindByIdAsync(PersonPhoneRequest personPhoneRequest);
        Task<PersonPhoneResponse> SaveAsync(PersonPhoneRequest personPhoneRequest);
        Task<PersonPhoneResponse> Delete(PersonPhoneRequest personPhoneRequest);
    }
}
