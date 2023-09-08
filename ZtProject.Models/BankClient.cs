using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ZtProject.Models
{
    public class BankClient 
    {

        [Key]
        [DisplayName("Citizen Number")]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }    

        [Required]
        public string Number { get; set; }

        [Required]
        public string MailAddress { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

      
    }
}
