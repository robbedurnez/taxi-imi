using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain.Models
{
    public class User : EntityBase
    {
        public UserType UserType { get; set; }
        public List<Address> Addresses { get; set; }
    }
}