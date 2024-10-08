using Microsoft.AspNetCore.Mvc;
using Project_Rest_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Project_Rest_API
{
    [Route("api/[controller]")]
    [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserDbContext _context;

    public UserController(UserDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User newUser)
    {
        if (_context.Users.Any(e => e.Id == newUser.Id))
        {
            return BadRequest("User with this ID already exists");
        }

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
    }

    [HttpGet]
    public async Task<ActionResult<IList<User>>> GetUsers(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 5)
    {
        var users = await _context.Users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(users);
    }
  }
}