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
        [RegularExpression(@"[A-Za-z]{3,20}$", ErrorMessage = "Username must be between 3 and 20 chars!")]
        public String ProductName { get; set; }
        [Required]
        public String ProductCategory { get; set; }
        [Required]
        public String ProductState { get; set; }
        public String ProductPhoto { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9]{20,250}$", ErrorMessage = "Desription must be between 20 and 250 chars!")]
        public String ProductDescription { get; set; }
        [Required]
        public String ProductLocation { get; set; }
        [RegularExpression(@"[A-Za-z0-9]{20,250}$", ErrorMessage = "Desription must be between 20 and 250 chars!")]
        public String ProductComment { get; set; }
        [Required]
        public int DonatorId { get; set; }
    }
}
