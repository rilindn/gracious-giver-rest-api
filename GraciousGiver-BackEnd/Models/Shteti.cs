﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Shteti : Controller
    {
            [Key]
            public int ShtetiId { get; set; }

            public String Emri { get; set; }
        
    }
}