using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain.Models
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}