using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Bussines.DTO;
using School.Bussines.Model;
using School.DataModel.Dbcontexts;

namespace School.Client.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContexts _appDbContexts;
        public UserController(AppDbContexts appDbContexts)
        {
            _appDbContexts = appDbContexts;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userobj)
        {
            try
            {
                if (userobj == null)
                
                    return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status400BadRequest, Message = "Bad Request", data = null });

                
                var user = await _appDbContexts.Users.FirstOrDefaultAsync(x => x.username == userobj.username && x.Password == userobj.Password);
                if (user == null)
                
                    return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status404NotFound, Message = "User not found!", data = null });
                        
                    return Ok(new ResultDTO {  Status=true,StatusCode= StatusCodes.Status200OK, Message = "Login Successfully!" });            }
            catch(Exception ex)

            {
                return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Internal Server Error " + ex.Message, data = null });

            }
        }
         
        
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        {
            try
            {
                if(userobj == null)
                    return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status400BadRequest, Message = "Bad Request", data = null });
                await _appDbContexts.Users.AddAsync(userobj);
                await _appDbContexts.SaveChangesAsync();
                return Ok(new ResultDTO { Status = true, StatusCode = StatusCodes.Status200OK, Message = " user Register Successfully!", data = userobj });

            }
            catch (Exception ex)
            {
                return Ok(new ResultDTO { Status = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Internal Server Error " + ex.Message, data = null });

            }
        }
    }
}
