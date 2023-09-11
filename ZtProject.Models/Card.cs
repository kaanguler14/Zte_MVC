using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      
        public long BankClientId { get; set; }
        [ForeignKey("BankClientId")]
        [ValidateNever]
        public BankClient BankClient { get; set; }

        public string ImageUrl { get; set; }

        
    }
}
