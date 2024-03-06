using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Bussines.Model
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public int Standard { get; set;}
        public long StudentPhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
       
    }
}
