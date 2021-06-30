using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Category name must be between 5 and 50 chars!")]
        public String ProductCategoryName { get; set; }
    }
}
