using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain.DTO
{
    public class CompanyDto : UserDto
    {
        [Required]
        public string Name { get; set; }
        public List<DriverDto> Drivers { get; set; }
        public List<OrderDto> Orders { get; set; }
        [Required]
        public decimal StartPrice { get; set; }
        [Required]
        public decimal PricePerKm { get; set; }
    }
}