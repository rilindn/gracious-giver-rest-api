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

        public int ProductProviderId { get; set; }
        public int ReceiverId { get; set; }
        public String Message { get; set; }
        public DateTime Offerdate { get; set; }
        public Boolean CheckOffer { get; set; }
        
    }
}
