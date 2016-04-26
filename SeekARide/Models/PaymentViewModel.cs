using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeekARide.Models
{
    public class PaymentViewModel
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }
        [Required]
        [Display(Name = "Card Type")]
        public string CardType { get; set; }
        [Required]
        [Display(Name = "Expiration Month")]
        public string Month { get; set; }
        [Required]
        [Display(Name = "Expiration Year")]
        public string Year { get; set; }
        [Required]
        public string CVV { get; set; }
        public string dummy { get; set; }


    }
}