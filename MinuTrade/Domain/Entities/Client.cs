using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace Domain.Entities
{
    public class Client
    {
        [Required]
        [BsonId]
        public string CPF { get; set; }

        [Required]
        public Address ClientAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public List<string> PhoneNumbers { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string MaritalStatus { get; set; }
    }
}