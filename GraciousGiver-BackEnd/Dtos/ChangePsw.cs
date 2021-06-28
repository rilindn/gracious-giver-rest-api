using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Dtos
{
    public class ChangePswDto
    {
        public String UserName { get; set; }
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }
}