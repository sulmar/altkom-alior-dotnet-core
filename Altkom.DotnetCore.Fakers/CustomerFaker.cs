using Altkom.DotnetCore.Models;
using Bogus;
using System;

namespace Altkom.DotnetCore.Fakers
{
    // dotnet add package Bogus
    public class CustomerFaker : Faker<Customer>
    {
        // snippet: ctor

        public CustomerFaker()
        {
            StrictMode(true);
            UseSeed(1);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
            Ignore(p => p.City);
            RuleFor(p => p.UserName, f => f.Person.UserName);
            RuleFor(p => p.HashPassword, f => "12345");
        }
    }
}
