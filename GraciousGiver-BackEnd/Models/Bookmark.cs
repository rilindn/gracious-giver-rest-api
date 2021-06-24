using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Bookmark
    {
        [Key]
        public int BookmarkId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
