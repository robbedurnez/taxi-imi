using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Taxi.Domain.DTO.Base;
using Taxi.Domain.Models;

namespace Taxi.Domain.DTO
{
    public class UserDto : DtoBase
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public UserType UserType { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
