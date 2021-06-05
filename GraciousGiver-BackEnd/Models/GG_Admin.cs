using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class GG_Admin
    {
        [Key]
        public int AdminId { get; set; }

        public String AdminName { get; set; }

        public Byte[] AdminPassword { get; set; }
        public String AdminEmail { get; set; }

        public String AdminGender { get; set; }

        public DateTime AdminDbo { get; set; }
    
    }
}
