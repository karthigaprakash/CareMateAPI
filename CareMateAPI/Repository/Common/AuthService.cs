using CareMateAPI.DatabaseContext;
using CareMateAPI.Model.Master;
using Microsoft.EntityFrameworkCore;

namespace CareMateAPI.Repository;

public class AuthRepository
{
    private readonly CareMateDbContext _context;

    public AuthRepository(CareMateDbContext context)
    {
        _context = context;
    }

    public async Task<User?> ValidateUserAsync(string email, string password)
    {
        return await _context.User
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password && !u.IsDelete);
    }
}