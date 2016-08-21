using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address
    {
        [Required]
        public string AddressLine { get; set; }
    }
}
