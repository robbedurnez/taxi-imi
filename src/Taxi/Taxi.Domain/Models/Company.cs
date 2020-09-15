using System.Collections.Generic;

namespace Taxi.Domain.Models
{
    public class Company : User
    {
        public string Name { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Order> Orders { get; set; }
        public decimal StartPrice { get; set; }
        public decimal PricePerKm { get; set; }
    }
}