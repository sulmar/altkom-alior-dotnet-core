using Altkom.DotnetCore.DbRepositories;
using Altkom.DotnetCore.FakeRepositories;
using Altkom.DotnetCore.Fakers;
using Altkom.DotnetCore.IRepositories;
using System;

namespace Altkom.DotnetCore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .NET Core!");

            GetCustomersTest();

            RemoveCustomerTest();
        }

        private static void RemoveCustomerTest()
        {
            ICustomerRepository customerRepository = new FakeCustomerRepository(new CustomerFaker());

            customerRepository.Remove(1);
        }

        private static void GetCustomersTest()
        {
            ICustomerRepository customerRepository = new FakeCustomerRepository(new CustomerFaker());

            var customers = customerRepository.Get();

            foreach (var customer in customers)
            {
                // decimal amount = customerRepository.Calculate(customer);

                Console.WriteLine($"{customer.Id} {customer.FirstName} {customer.LastName} {customer.City} {customer.IsRemoved}");
            }

        }
    }
}
