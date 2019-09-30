using System;

namespace Altkom.DotnetCore.Models
{

    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsRemoved { get; set; }
        public string City { get; set; }
    }
}
