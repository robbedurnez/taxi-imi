using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Taxi.Domain.Models;

namespace Taxi.Domain.DTO
{
    public class UserPostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public UserType UserType { get; set; }

        public string CompanyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public AddressDto Address { get; set; }
    }
}
