using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace GraciousGiver_BackEnd.Models
{
    public class Street
    {
        [Key]
        public int StreetId { get; set; }
        [Required]
        [RegularExpression(@"^.*?\s[N]{0,1}([-a-zA-Z0-9]+)\s*\w*$", ErrorMessage = "Invalid street name!")]
        public String StreetName { get; set; }
    }
}
