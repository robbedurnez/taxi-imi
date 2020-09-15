using System.Collections.Generic;

namespace Taxi.MobileApp.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Order> Orders { get; set; }
        public double StartPrice { get; set; }
        public double PricePerKm { get; set; }
    }
}