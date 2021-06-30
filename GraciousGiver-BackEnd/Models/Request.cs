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
        [RegularExpression(@"/[a-zA-Z0-9]{20,254}$/", ErrorMessage = "Desription must be between 20 and 254 chars!")]
        public String RequestDescription { get; set; }
        [Required]
        [RegularExpression(@"/[a-zA-Z]{5,50}$/", ErrorMessage = "Name must be between 5 and 50 chars!")]
        public String RequestName { get; set; }
        [Required]
        public String RequestCategory { get; set; }
        [Required]
        public String RequestLocation { get; set; }
       
        public String RequestComment { get; set; }
        [Required]
        public String RequestPhoto { get; set; }

        public int ReceiverId { get; set; }
    }
}
