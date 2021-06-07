using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Dtos
{
    public class RegisterDto
    {
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
