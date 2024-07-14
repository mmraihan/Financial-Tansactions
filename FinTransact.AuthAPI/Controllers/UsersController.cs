using FinTransact.AuthAPI.Data;
using FinTransact.AuthAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinTransact.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _db;

        public UsersController(DataContext db)
        {
            _db = db;
        }


        [HttpGet("get-all-users")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {

            return await _db.Users.ToListAsync();
        }

        [HttpGet("get-user/{id}")]

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _db.Users.FindAsync(id);
        }
    }
}
