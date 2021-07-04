using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Product_Request
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 300 chars!")]
        public String Message { get; set; }
        [Required]
        public DateTime Request_Date { get; set; }
        [Required]
        public Boolean checkedR {get; set;}

        public int GetReqProductId()
        {
            return ProductId;
        }
    }


}
