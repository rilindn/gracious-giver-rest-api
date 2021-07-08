using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Iniciative
    {
        [Key]
        public int IniciativeId { get; set; }

        public String IniciativeName { get; set; }

        public String IniciativeDescription { get; set; }


        public DateTime IniciativeDate { get; set; }

        public int OrganizationId { get; set; }
        public int ReceiverId { get; set; }
    }
}
