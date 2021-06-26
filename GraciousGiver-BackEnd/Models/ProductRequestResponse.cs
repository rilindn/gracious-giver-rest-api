﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class ProductRequestResponse
    {
        [Key]
        public int ProductRequestResponseId { get; set; }
        public int RequestId { get; set; }
        public int DonatorId { get; set; }
        public int ReceiverId { get; set; }
        public String Response { get; set; }
        public String Message { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
