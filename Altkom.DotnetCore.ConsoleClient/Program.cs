using Altkom.DotnetCore.FakeRepositories;
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
        }

        private static void GetCustomersTest()
        {
            ICustomerRepository customerRepository = new FakeCustomerRepository();

            var customers = customerRepository.Get();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id} {customer.FirstName} {customer.LastName} {customer.City} {customer.IsRemoved}");
            }

        }
    }
}
