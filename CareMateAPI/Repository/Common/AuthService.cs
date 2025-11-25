using CareMateAPI.DatabaseContext;
using CareMateAPI.Model.Master;
using Microsoft.EntityFrameworkCore;

namespace CareMateAPI.Repository;

public class AuthService
{
    private readonly CareMateDbContext _context;
    private readonly JwtTokenService _jwtTokenService;

    public AuthService(CareMateDbContext context, JwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    public string Login(int id, string password)
    {
        var user = _context.User.FirstOrDefault(u => u.Id == id && u.Password == password);

        if (user == null) return null;

        return _jwtTokenService.GenerateToken(user);
    }
}