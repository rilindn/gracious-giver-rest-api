using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class RequestPhotos
    {
        [Key]
        public int PhotoId { get; set; }
        public int Request { get; set; }

        public String RequestPhotoPath { get; set; }
    }
}
