using System;
using Taxi.Domain.Models;

namespace Taxi.MobileApp.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string DriverId { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        public double TotalPrice { get; set; }
    }
}