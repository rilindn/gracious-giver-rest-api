using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class InitiativeRequest

    {
        [Key]
        public int InitativeRequestId { get; set; }
        [Required]

        public int OrganizationId { get; set; }
        [Required]

        public int UserId { get; set; }
        [Required]

        public string Request { get; set; }

        [Required]


        public DateTime DateOfJoining { get; set; }
        [Required]

        public bool Checked { get; set; }
        [Required]
        public string Response { get; set; }
    }
}
