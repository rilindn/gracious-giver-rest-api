using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class City     
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Cityname must be between 5 and 50 chars!")]
        public String CityName { get; set; }
    }
}


