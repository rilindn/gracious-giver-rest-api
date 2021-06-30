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
        [RegularExpression(@"/[a-zA-Z]{10,50}$/", ErrorMessage = "Username must be between 10 and 50 chars!")]
        public String ProductName { get; set; }
        [Required]
        public String ProductCategory { get; set; }
        [Required]
        public String ProductState { get; set; }
        [Required]
        public String ProductPhoto { get; set; }
        [Required]
        [RegularExpression(@"/[a-zA-Z0-9]{20,254}$/", ErrorMessage = "Desription must be between 20 and 254 chars!")]
        public String ProductDescription { get; set; }
        [Required]
        public String ProductLocation { get; set; }

        public String ProductComment { get; set; }

        public int DonatorId { get; set; }
    }
}
