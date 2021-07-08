using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }

        public String EventName { get; set; }

        public String EventDescription { get; set; }

        public String City { get; set; }

        public DateTime EventDate { get; set; }

        public int OrganizationId { get; set; }
    }
}
