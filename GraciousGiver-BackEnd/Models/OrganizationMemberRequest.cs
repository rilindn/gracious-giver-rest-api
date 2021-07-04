﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class OrganizationMemberRequest
    {
        [Key]
        public int OrganizationMemberRequestId { get; set; }

        public int OrganizationId { get; set; }

        public int UserId { get; set; }

        public DateTime DateOfJoining { get; set; }

        public Boolean Checked { get; set; }
    }
}
