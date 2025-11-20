namespace CareMateAPI.Model.Master;

public class UserRole
{
    public int? UserRoleId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public bool IsDelete { get; set; } = false;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}