using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseMicroService.Models
{
    public class Purchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        public float Price { get; set; }
    }
}
