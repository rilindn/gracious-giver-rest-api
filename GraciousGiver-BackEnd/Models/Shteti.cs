using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Shteti 
    {
            [Key]
            public int ShtetiId { get; set; }
            [Required]
            [RegularExpression(@"/[a-zA-Z]{5,50}$/", ErrorMessage = "State name must be between 5 and 50 chars!")]
            public string Emri { get; set; }
        
    }
}
