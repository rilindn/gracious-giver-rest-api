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
        [StringLength(50,MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 chars!")]
        public String OfferedProductResponseName { get; set; }
        [Required]
        public int OfferProductId { get; set; }
        [Required]
        public DateTime OfferedProductResponseDate { get; set; }
        [Required]
        public int OfferedProductId { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Message must be between 19 and 300 chars!")]
        public String Message { get; set; }
        [Required]
        public int ProductProviderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
    }
}
