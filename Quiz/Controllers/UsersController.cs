using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity.Models;
using Entity.Data;
using BusinessCore.Interfaces;
using Common.DTO.User;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly SchoolDbContext _context;
    private readonly IUserService _userService;

    public UsersController(SchoolDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }
   

    // GET: api/User
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUser()
    {
        var users = await _userService.GetUser();
        return Ok(users);
    }

    // GET: api/User
    [HttpGet("GetuserReults")]
    public async Task<ActionResult<IEnumerable<User>>> GetuserReults()
    {
        return await _context.Users.ToListAsync();
    }

    // GET: api/User/5
    [HttpGet("{userid}")]
    public async Task<ActionResult<User>> GetUser(int userid)
    {
        var user = await _context.Users.FindAsync(userid);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{userid}")]
    public async Task<IActionResult> PutUser(int? userid, User user)
    {
        if (userid != user.UserId)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(userid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { userid = user.UserId }, user);
    }

    // DELETE: api/User/5
    [HttpDelete("{userid}")]
    public async Task<IActionResult> DeleteUser(int? userid)
    {
        var user = await _context.Users.FindAsync(userid);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(int? userid)
    {
        return _context.Users.Any(e => e.UserId == userid);
    }
}
