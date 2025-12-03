namespace CareMateAPI.Model.Master;

public class Role
{
    public int? RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public bool IsDelete { get; set; } = false;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<UserRole>? UserRoles { get; set; }
}