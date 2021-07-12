﻿using GraciousGiver_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Dtos
{
    public class RegisterDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z]{2,20}$", ErrorMessage = "Firstname must be between 2 and 20 chars!")]
        public string Firstname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z]{2,20}$", ErrorMessage = "Lastname must be between 2 and 20 chars!")]
        public string Lastname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{7,30}$", ErrorMessage = "Username must be between 7 and 30 chars!")] 
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must contain more than 8 chars an at least one number!")]
        public string UserPassword { get; set; }
        [Required]
        public string UserConfirmPassword { get; set; }
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
        public string UserConfirmEmail { get; set; }
        [Required]
        public string UserGender { get; set; }
        [Required]
        [MinAge(18)]
        public DateTime UserDbo { get; set; }
    }
}
