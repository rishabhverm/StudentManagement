using Microsoft.AspNetCore.Mvc;
using School.Bussines.Abstartion;
using School.Bussines.DTO;
using School.Bussines.Model;
using System.Net;

namespace School.Client.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult>AddStudent([FromBody]AdminDTO adminDTO)
        {
            try
            {
                if(adminDTO == null)
                {
                    return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status400BadRequest, Message = "Bad Request" , data = null });

                }
                else
                {
                    Admin admin= new Admin();
                    {
                      admin.StudentName = adminDTO.StudentName;
                      admin.StudentEmail = adminDTO.StudentEmail;
                      admin.Standard = adminDTO.Standard;
                      admin.StudentPhoneNumber= adminDTO.StudentPhoneNumber;
                      admin.Address = adminDTO.Address;
                    };
                    await _adminRepository.AddStudent(admin);
                    return Ok(new ResultDTO { Status = true, StatusCode = StatusCodes.Status200OK, Message = "Student Added successfully", data = admin });
                }
            }
            catch (Exception ex) 
            {
                return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Internal Server Error " + ex.Message, data = null });

            }
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var student = await _adminRepository.GetAllStudent();
                return Ok(new ResultDTO { Status = true, StatusCode = StatusCodes.Status200OK, Message = "All students retrieved successfully", data = student });

            }
            catch (Exception ex)
            {
                return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Internal Server Error " + ex.Message, data = null });

            }
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var found = await _adminRepository.GetStudentById(id);
                if (found == null)
                {
                    return Ok(new ResultDTO { Status = true, StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Any Student by this {id}", data=null });

                }
                else
                {
                    return Ok(new ResultDTO { Status = true, StatusCode = StatusCodes.Status200OK, Message = "Student Retrive successfully", data = found });

                }
            }
            catch (Exception ex)
            {
                return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Internal Server Error " + ex.Message, data = null });

            }
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] AdminDTO admindto)
        {
            try
            {
                var existingStudent = await _adminRepository.GetStudentById(id);

                if (existingStudent == null)
                {
                    return NotFound(new ResultDTO { Status = false, StatusCode = StatusCodes.Status404NotFound, Message = $"No student found with ID: {id}", data = null });
                }

                existingStudent.StudentName = admindto.StudentName;
                existingStudent.StudentEmail = admindto.StudentEmail;
                existingStudent.Standard = admindto.Standard;
                existingStudent.StudentPhoneNumber = admindto.StudentPhoneNumber;
                existingStudent.Address = admindto.Address;

                await _adminRepository.UpdateStudent(existingStudent);

                return Ok(new ResultDTO { Status = true, StatusCode = StatusCodes.Status200OK, Message = "Student data updated successfully", data = existingStudent });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResultDTO { Status = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Internal Server Error: " + ex.Message, data = null });
            }
        }
    }

}

