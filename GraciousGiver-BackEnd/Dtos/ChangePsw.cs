using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Dtos
{
    public class ChangePswDto
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String OldPassword { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must contain more than 8 chars an at least one number!")]
        public String NewPassword { get; set; }
    }
}