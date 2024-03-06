using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Bussines.DTO
{
    public class AdminDTO
    {
        [Required, MaxLength(100)]
        public string StudentName { get; set; }
        [Required, MaxLength(100)]
        public string StudentEmail { get; set; }
        public int Standard { get; set; }
        public long StudentPhoneNumber { get; set; }
        [Required, MaxLength(1000)]
        public string Address { get; set; }

    }
}
