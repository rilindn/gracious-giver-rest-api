using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class EventParticipants
    {
        [Key]
        
        public int EventParticipantId  {get; set;}
        [Required]
        public int EventId  { get; set; }
        [Required]
        public int ParticipantId { get; set; }

    }
}
