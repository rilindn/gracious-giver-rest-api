using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class OfferedProductResponse

    {
        [Key]
        public int OfferedProductResponseId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Name must be between 5 and 50 chars!")]
        public String OfferedProductResponseName { get; set; }
        [Required]
        public int Responseid { get; set; }
        [Required]
        public DateTime OfferedProductResponseDate { get; set; }
        [Required]
        public int OfferedProductId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Message must be between 5 and 50 chars!")]
        public String Message { get; set; }
        [Required]
        public int ProductProviderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
    }
}
