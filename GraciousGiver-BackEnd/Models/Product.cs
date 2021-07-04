using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Product name must be between 5 and 50 chars!")]
        public string ProductName { get; set; }
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public string ProductState { get; set; }
        public string ProductPhoto { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 400 chars!")]
        public string ProductDescription { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Max length is 200 chars!")]
        public string ProductComment { get; set; }
        [Required]
        public int DonatorId { get; set; }
    }
}
