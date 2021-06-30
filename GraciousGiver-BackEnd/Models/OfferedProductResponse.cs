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

        public String OfferedProductResponseName { get; set; }
        
        public int Responseid { get; set; }

        public DateTime OfferedProductResponseDate { get; set; }

        public int OfferedProductId { get; set; }

        public String Message { get; set; }

        public int ProductProviderId { get; set; }

        public int ReceiverId { get; set; }
    }
}
