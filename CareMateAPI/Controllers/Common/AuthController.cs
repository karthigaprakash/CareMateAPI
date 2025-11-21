using CareMateAPI.DatabaseContext;
using CareMateAPI.Model.Master;
using CareMateAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMateAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(JwtTokenService jwtService, CareMateDbContext dbContext) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        if (user != null && user.Id != null && user.Password != null)
        {
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.IsDelete = false;

            dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();

            var token = jwtService.GenerateToken(user);
            return Ok(new { Token = token, UserId = user.Id });
        }

        return Unauthorized("Invalid credentials");
    }
}