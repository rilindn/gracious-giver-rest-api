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
        [Required]
        public String EventName { get; set; }
        [Required]
        public String EventDescription { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public String Photo { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public int OrganizationId { get; set; }
    }
}
