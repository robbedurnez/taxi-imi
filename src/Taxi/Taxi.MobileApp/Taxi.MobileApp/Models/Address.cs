namespace Taxi.MobileApp.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string FullAddressLine => $"{AddressLine1} {AddressLine2}";
        public string FullAddress => $"{AddressLine1} {AddressLine2}, {City}";
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
