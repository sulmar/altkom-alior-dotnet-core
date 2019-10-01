using Altkom.DotnetCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.DotnetCore.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        ICollection<Customer> GetByCity(string city);

        // Customer Authorize(string username, string hashPasword);

        bool TryAuthorize(string username, string hashPasword, out Customer customer);
    }
}
