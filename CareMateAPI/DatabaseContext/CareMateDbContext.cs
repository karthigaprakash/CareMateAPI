namespace CareMateAPI.DatabaseContext;

public class CareMateDbContext(DbContextOptions<CareMateDbContext> options) : DbContext(options)
{
    public DbSet<Role> Roles { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }
}