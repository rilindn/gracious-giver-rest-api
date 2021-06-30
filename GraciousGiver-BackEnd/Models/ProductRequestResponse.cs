using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class ProductRequestResponse
    {
        [Key]
        public int ProductRequestResponseId { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int DonatorId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Response must be between 5 and 50 chars!")]
        public String Response { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{20,150}$", ErrorMessage = "Message must be between 20 and 150 chars!")]
        public String Message { get; set; }
        [Required]
        public DateTime ResponseDate { get; set; }
    }
}
