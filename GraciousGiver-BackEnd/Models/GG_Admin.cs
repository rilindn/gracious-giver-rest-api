using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Models
{
    public class GG_Admin
    {
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        [Key]
        public int AdminId { get; set; }
        public String AdminName { get; set; }


        [DataType(DataType.Password)]
        public Byte[] AdminPassword { get; set; }
        public String AdminEmail { get; set; }

        public String AdminGender { get; set; }

        public DateTime AdminDbo { get; set; }
    
    }
}
