using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Taxi.Domain.DTO.Base;
using Taxi.Domain.Models;

namespace Taxi.Domain.DTO
{
    public class OrderDto : DtoBase
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string DriverId { get; set; }
        [Required]
        public string FromId { get; set; }
        [Required]
        public string ToId { get; set; }
        public string CompanyId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderState State { get; set; }
        public decimal TotalPrice { get; set; }
    }
}