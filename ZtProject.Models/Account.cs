using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZtProject.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ValidateNever]
        public string? IBAN { get; set; }
        [Required]
        
        public string? AccountType { get; set; }
        [Required]
        [ValidateNever]
        public double AccountBalance { get; set; }
        [ValidateNever]
        [Required]
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

       

        [Required]
        [DisplayName("Account Status")]
      
        public string? AccountStatus { get; set; }

        [ValidateNever]
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        [ValidateNever]
        public ApplicationUser Client { get; set; }


    }
}
