using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Notifications
    {
        [Key]
        public int NotificationId { get; set; }

        public int Initiator { get; set; }

        public int Acceptor { get; set; }

        public String Content { get; set; }

        public DateTime Date { get; set; }

        public Boolean Readed { get; set; }
    }
}
