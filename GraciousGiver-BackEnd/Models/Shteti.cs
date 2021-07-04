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
            public string Emri { get; set; }
        
    }
}
