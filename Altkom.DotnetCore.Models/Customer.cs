using System;

namespace Altkom.DotnetCore.Models
{

    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsRemoved { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
    }
}
