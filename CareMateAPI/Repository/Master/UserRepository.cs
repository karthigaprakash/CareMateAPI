namespace CareMateAPI.Repository;

public class UserRepository(CareMateDbContext context)
{
    public async Task<Response<List<User>>> GetUsers()
    {
        try
        {
            var users = await context.User.Where(x => !x.IsDelete).ToListAsync();

            return Response<List<User>>.Success(users);
        }
        catch (Exception ex)
        {
            return Response<List<User>>.Error(ex.Message);
        }
    }

    public async Task<Response<User>> GetUserById(int? userId)
    {
        try
        {
            var user = await context.User.FindAsync(userId);

            if (user != null)
            {
                return Response<User>.Success(user);
            }

            return Response<User>.Error("Invalid User Id");
        }
        catch (Exception ex)
        {
            return Response<User>.Error(ex.Message);
        }
    }

    public async Task<Response<User>> SaveOrUpdate(User user)
    {
        try
        {
            if (user.Id == null || user.Id == 0)
            {
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = null;

                await context.User.AddAsync(user);
                await context.SaveChangesAsync();

                return Response<User>.Success(user, "User Saved Successfully");
            }

            var userInDb = await context.User.FindAsync(user.Id);

            if (userInDb != null)
            {
                userInDb.UserName = user.UserName;
                userInDb.Email = user.Email;
                userInDb.Password = user.Password;
                userInDb.MobileNumber = user.MobileNumber;
                userInDb.ModifiedDate = DateTime.Now;

                await context.SaveChangesAsync();

                return Response<User>.Success(userInDb, "User Updated Successfully"); // ✅ FIXED
            }

            return Response<User>.Error("User not found");
        }
        catch (DbUpdateException ex)
        {
            var inner = ex.InnerException?.Message ?? ex.Message;
            return Response<User>.Error($"Database error: {inner}");
        }
        catch (Exception ex)
        {
            return Response<User>.Error($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<Response<string>> UpdateRoleForUser(int? userId, int? roleId)
    {
        try
        {
            var user = await context.User.FindAsync(userId);
            var role = await context.Roles.FindAsync(roleId);

            if (user == null)
            {
                return Response<string>.Error("Invalid User Id");
            }

            if (role == null)
            {
                return Response<string>.Error("Invalid Role Id");
            }

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();

            return Response<string>.Success("Role Updated Successfully");
        }
        catch (Exception ex)
        {
            return Response<string>.Error(ex.Message);
        }
    }
}