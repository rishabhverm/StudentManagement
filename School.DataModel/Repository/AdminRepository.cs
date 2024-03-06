using Microsoft.EntityFrameworkCore;
using School.Bussines.Abstartion;
using School.Bussines.Model;
using School.DataModel.Dbcontexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContexts _dbcontexts;
        public AdminRepository(AppDbContexts dbcontexts)
        {
            _dbcontexts = dbcontexts;
        }

        public async Task<Admin> AddStudent(Admin admin)
        {
            await _dbcontexts.Admins.AddAsync(admin);
            await _dbcontexts.SaveChangesAsync(); 
            return admin;

        }

        public async Task<IEnumerable<Admin>> GetAllStudent()
        {
            return await _dbcontexts.Admins.ToListAsync();
        }

        public async Task<Admin> GetStudentById(int id)
        {
           return await _dbcontexts.Admins.Where(admin=>admin.ID == id).FirstOrDefaultAsync();
        }

        public async Task<Admin> UpdateStudent(Admin admin)
        {
           _dbcontexts.Admins.Update(admin);
            await _dbcontexts.SaveChangesAsync(); 
            return admin;
        }
    }
}
