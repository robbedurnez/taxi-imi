using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain.DTO
{
    public class DriverDto : UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string CompanyId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; }
    }
}