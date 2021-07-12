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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Response must be between 3 and 50 chars!")]
        public String Response { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 300 chars!")]
        public String Message { get; set; }
        [Required]
        public DateTime ResponseDate { get; set; }
    }
}
