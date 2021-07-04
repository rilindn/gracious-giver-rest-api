using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{5,50}$", ErrorMessage = "Username must be between 5 and 50 chars!")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must contain more than 8 chars an at least one number!")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Documentation { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [StringLength(700, MinimumLength = 50, ErrorMessage = "Message must be between 50 and 700 chars!")]
        public string Description { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
    }
}
