using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public String ProductName { get; set; }

        public String ProductCategory { get; set; }

        public String ProductState { get; set; }

        public String ProductPhoto { get; set; }

        public String ProductDescription { get; set; }

        public String ProductLocation { get; set; }

        public String ProductComment { get; set; }

        public int DonatorId { get; set; }
    }
}
