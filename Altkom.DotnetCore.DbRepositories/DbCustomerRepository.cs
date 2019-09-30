using Altkom.DotnetCore.IRepositories;
using Altkom.DotnetCore.Models;
using System;
using System.Collections.Generic;

namespace Altkom.DotnetCore.DbRepositories
{
    public class DbCustomerRepository : ICustomerRepository
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetByCity(string city)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
