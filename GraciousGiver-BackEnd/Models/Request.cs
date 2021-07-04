using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Request
    {
        [Key]
        public int RequesttId { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 400 chars!")]
        public string RequestDescription { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Request name must be between 5 and 50 chars!")]
        public string RequestName { get; set; }
        [Required]
        public string RequestCategory { get; set; }
        [Required]
        public string RequestLocation { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Max length is 200 chars!")]
        public string RequestComment { get; set; }
        [Required]
        public string RequestPhoto { get; set; }
        [Required]
        public int ReceiverId { get; set; }
    }
}
