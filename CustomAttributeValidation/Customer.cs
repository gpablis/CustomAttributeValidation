using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributeValidation
{
    public class Customer
    {
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public Address? Address { get; set; }
    }

    public class Address
    {
        [Required]
        public string? AddressName { get; set; }
        [Required]
        public int? AddressNumber { get; set; }
    }
}
