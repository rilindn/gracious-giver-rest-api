using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Qyteti     
    {
        [Key]
        public int CityId { get; set; }

        public String CityName { get; set; }
    }
}


