using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class OfferProduct
    {
        [Key]
        public int OfferProductId { get; set; }
        [Required]
        public int ProductProviderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]{10,150}$", ErrorMessage = "Message must be between 10 and 150 chars!")]
        public string Message { get; set; }
        [Required]
        public DateTime Offerdate { get; set; }
        public Boolean CheckOffer { get; set; }
        
    }
}
