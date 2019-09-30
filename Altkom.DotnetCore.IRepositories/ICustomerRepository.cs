using Altkom.DotnetCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.DotnetCore.IRepositories
{
    public interface ICustomerRepository
    {
        ICollection<Customer> Get();
        Customer Get(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);
    }
}
