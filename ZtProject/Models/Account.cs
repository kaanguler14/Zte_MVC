using System.ComponentModel.DataAnnotations;

namespace ZtProject.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IBAN { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public double AccountBalance { get; set; }
        [Required]
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

        [Required]
        public string AccountHolder { get; set; }

        [Required]
        public string AccountStatus { get; set; }

       



    }
}
