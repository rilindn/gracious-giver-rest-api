﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class OrganizationCategory
    {
        [Key]
        public int OrganizationCategoryId { get; set; }
        [Required]
        public String OrganizationCategoryName { get; set; }
    }
}
