using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain.Models
{
    public class Driver : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; }
    }
}