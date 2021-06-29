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
        [RegularExpression(@"^[a - zA - Z0 - 9] + ([._]?[a - zA - Z0 - 9] +) *$", ErrorMessage = "Username must be between 8 and 20 chars!")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/;", ErrorMessage = "Password must contain more than 8 chars an at least one number!")]
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
        public string UserGender { get; set; }
        [Required]
        [MinAge(18)]
        public DateTime UserDbo { get; set; }
    }
}
