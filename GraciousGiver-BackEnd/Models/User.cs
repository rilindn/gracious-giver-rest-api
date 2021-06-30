using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z]{3,20}$", ErrorMessage = "Firstname must be between 3 and 20 chars!")]
        public string Firstname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z]{3,20}$", ErrorMessage = "Lastname must be between 3 and 20 chars!")]
        public string Lastname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{7,30}$", ErrorMessage = "Username must be between 7 and 30 chars!")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must contain more than 8 chars an at least one number!")]
        public string UserPassword { get; set; }
        [Required]
        public string UserState { get; set; }
        [Required]
        public string UserCity { get; set; }
        [Required]
        public int UserPostcode { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string UserEmail { get; set; }
        [Required]
        public string UserGender { get; set; }
        [Required]
        [MinAge(18)]
        public DateTime UserDbo { get; set; }

    }
}
