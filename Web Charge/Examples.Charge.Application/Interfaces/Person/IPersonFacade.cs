﻿using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonResponse> FindById(int id);
        Task<PersonResponse> SaveAsync(PersonRequest personRequest);
    }
}