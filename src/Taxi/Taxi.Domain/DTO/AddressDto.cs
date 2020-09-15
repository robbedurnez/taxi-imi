using System.ComponentModel.DataAnnotations;
using Taxi.Domain.DTO.Base;

namespace Taxi.Domain.DTO
{
    public class AddressDto : DtoBase
    {
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        public string UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
