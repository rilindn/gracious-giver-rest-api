using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class ChatMsg
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public int AcceptorId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime msgDateTime { get; set; }
        [Required]
        public int Chat { get; set; }
    }
}
