using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Request
    {
        [Key]
        public int RequesttId { get; set; }

        public String RequestDescription { get; set; }

        public String RequestName { get; set; }

        public String RequestCategory { get; set; }

        public String RequestLocation { get; set; }

        public String RequestComment { get; set; }

        public String RequestPhoto { get; set; }

        public int ReceiverId { get; set; }
    }
}
