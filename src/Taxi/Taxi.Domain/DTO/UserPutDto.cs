using Taxi.Domain.DTO.Base;

namespace Taxi.Domain.DTO
{
    public class UserPutDto : DtoBase
    {
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
    }
}