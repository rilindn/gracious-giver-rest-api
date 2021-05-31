using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class ProductPhotos
    {
        [Key]
        public int PhotoId { get; set; }
        public int Product { get; set; }

        public String ProductPhotoPath { get; set; }
    }
}
