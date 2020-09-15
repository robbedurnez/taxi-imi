using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Domain.Models
{
    public class Order : EntityBase
    {
        public string UserId { get; set; }
        public string DriverId { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string CompanyId { get; set; }
        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        public decimal TotalPrice { get; set; }
    }
}