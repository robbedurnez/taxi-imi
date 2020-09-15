using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain.DTO
{
    public class CustomerDto : UserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}