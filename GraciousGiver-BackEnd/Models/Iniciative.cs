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
        [Required]
        public string IniciativeName { get; set; }
        [Required]
        public string IniciativeDescription { get; set; }
        [Required]
        public string IniciativePhoto { get; set; }
        [Required]
        public DateTime IniciativeDate { get; set; }
        [Required]
        public int OrganizationId { get; set; }
        public int ReceiverId { get; set; }
    }
}
