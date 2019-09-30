using Altkom.DotnetCore.Fakers;
using Altkom.DotnetCore.IRepositories;
using Altkom.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.FakeRepositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private ICollection<Customer> customers;

        private CustomerFaker customerFaker;

        public FakeCustomerRepository()
        {
            customerFaker = new CustomerFaker();

            customers = customerFaker.Generate(100);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public ICollection<Customer> Get()
        {
            return customers.ToList();
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
