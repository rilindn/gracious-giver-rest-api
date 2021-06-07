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
        public String UserName { get; set; }
        public String UserPassword { get; set; }
        public String UserState { get; set; }
        public String UserCity { get; set; }
        public int UserPostcode { get; set; }
        public String UserRole { get; set; }
        public String UserEmail { get; set; }
        public String UserGender { get; set; }
        public DateTime UserDbo { get; set; }

    }
}
