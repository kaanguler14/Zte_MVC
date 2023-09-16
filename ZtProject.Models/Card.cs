using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace ZtProject.Models
{
    public class Card
    {
       [Key]     
       public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string number { get; set; }

        public long limit { get; set; }

        [ValidateNever]
        public string BankClientId { get; set; }
        [ForeignKey("BankClientId")]
        [ValidateNever]
        public ApplicationUser BankClient { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        
    }
}
