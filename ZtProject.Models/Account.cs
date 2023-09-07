﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [ValidateNever]
        public string? AccountType { get; set; }
        [Required]
        public double AccountBalance { get; set; }
        [Required]
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

        [Required]
        [DisplayName("Account Holder")]
        [MinLength(1)]
        public string? AccountHolder { get; set; }

        [Required]
        [DisplayName("Account Status")]
        [ValidateNever]
        public string? AccountStatus { get; set; }


        [ForeignKey("AccountId")]
        [ValidateNever]
        public BankClient? Client { get; set; }


    }
}