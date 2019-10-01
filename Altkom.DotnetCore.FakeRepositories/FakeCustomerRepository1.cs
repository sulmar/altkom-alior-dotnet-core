using Altkom.DotnetCore.IRepositories;
using Altkom.DotnetCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.FakeRepositories
{
    public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
    {
        public FakeCustomerRepository(Faker<Customer> entityFaker) : base(entityFaker)
        {
        }

        public ICollection<Customer> GetByCity(string city)
        {
            throw new NotImplementedException();
        }


        public new void Remove(int id)
        {
            Customer customer = Get(id);
            customer.IsRemoved = true;
        }

        public bool TryAuthorize(string username, string hashPasword, out Customer customer)
        {
            customer = entities.SingleOrDefault(e => e.UserName == username && e.HashPassword == hashPasword);

            return customer != null;
        }
    }
}
