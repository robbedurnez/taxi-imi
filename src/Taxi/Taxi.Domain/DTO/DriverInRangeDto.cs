using Taxi.Domain.DTO.Base;

namespace Taxi.Domain.DTO
{
    public class DriverInRangeDto : DtoBase
    {
        public string DriverId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CompanyName { get; set; }
        public int MaxDistanceInKm { get; set; }
        public bool IsAvailable { get; set; }
    }
}