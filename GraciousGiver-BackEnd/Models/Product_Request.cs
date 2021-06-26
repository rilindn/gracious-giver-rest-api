using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class Product_Request
    {
        [Key]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public String Message { get; set; }
        public DateTime Request_Date { get; set; }
        public Boolean checkedR {get; set;}

        public int GetReqProductId()
        {
            return ProductId;
        }
    }


}
