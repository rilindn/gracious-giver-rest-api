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
        [RegularExpression(@"/[a-zA-Z]{3,30}$/", ErrorMessage = "Name must be between 3 and 30 chars!")]
        public String ProductCategoryName { get; set; }
    }
}
