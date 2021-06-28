using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class PendingOrganizationsRequest
    {
        [Key]
        public int OrganizationId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Category { get; set; }
        public String Description { get; set; }
        public String Location { get; set; }
        public Boolean Checked { get; set; }

    }
}
