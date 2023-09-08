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
    public class CardHistory
    {
        [Key]
        public int Id { get; set; }

        public string PlaceName { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public string Type { get; set; }


        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public Card Card { get; set; }
    }
}
