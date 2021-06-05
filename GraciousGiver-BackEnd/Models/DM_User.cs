using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class DM_User
    {
        [Key]
        public int UserId { get; set; }

        public String UserName { get; set; }

        public Byte[] UserPassword { get; set; }
        public String UserState { get; set; }
        public String UserCity { get; set; }
        public int UserPostcode { get; set; }


        public String UserRole { get; set; }
        public String UserEmail { get; set; }

        public String UserGender { get; set; }

        public DateTime UserDbo { get; set; }

    }
}
