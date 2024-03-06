using School.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Bussines.Abstartion
{
    public interface IAdminRepository
    {
        public Task<IEnumerable<Admin>> GetAllStudent();
        public Task <Admin>GetStudentById(int id);
        public Task<Admin> AddStudent(Admin admin);
        public Task<Admin> UpdateStudent(Admin admin);
    }
}
