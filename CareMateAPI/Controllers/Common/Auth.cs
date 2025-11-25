using CareMateAPI.DatabaseContext;
using CareMateAPI.Model.Master;
using CareMateAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMateAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Auth(AuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromQuery] int id, [FromQuery] string password)
    {
        var token = authService.Login(id, password);
        if (token == null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(new { Token = token, Id = id});
    }
}