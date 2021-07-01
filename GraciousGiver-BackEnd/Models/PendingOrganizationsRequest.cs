using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class PendingOrganizationsRequest
    {
        [Key]
        public int OrganizationId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Username must be between 5 and 50 chars!")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must contain more than 8 chars an at least one number!")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{5,50}$", ErrorMessage = "Name must be between 5 and 50 chars!")]
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
        [RegularExpression(@"[a-zA-Z0-9]{20,150}$", ErrorMessage = "Description must be between 20 and 150 chars!")]
        public string Description { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        
        [Required]
        public Boolean Checked { get; set; }

    }
}
