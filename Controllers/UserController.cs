using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public UsersController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

        [HttpPost("api/[controller]/login")]
        public IActionResult Login([FromBody] UserLogin userObj)
        {
            var user = _dbContext.Users.FirstOrDefault(usr => usr.Email == userObj.Email && usr.Password == userObj.Password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }
    }
}