namespace Taxi.MobileApp.Models
{
    public class Driver
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}