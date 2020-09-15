using System.Collections.Generic;
using Taxi.Domain.Models;

namespace Taxi.MobileApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public UserType UserType { get; set; }
    }
}
