using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace GraciousGiver_BackEnd.Models
{
    public class Street
    {
        [Key]
        public int StreetId { get; set; }

        public String StreetName { get; set; }
    }
}
