namespace CareMateAPI.Model.Master;

public class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? MobileNumber { get; set; }

    public bool IsDelete { get; set; } = false;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
