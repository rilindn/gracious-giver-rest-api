using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }
        [Required]
        public int AcceptorId { get; set; }
        [Required]
        public int SenderId { get; set; }
    }
}
