namespace CareMateAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
public class BaseController() : Controller
{
    protected int? CurrentUserId =>
        int.TryParse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value, out var userId) ?
        userId :
        (int?)null;

    protected string? CurrentUserName => User.FindFirst(ClaimTypes.Name)?.Value;

    protected string? CurrentUserEmail => User.FindFirst(ClaimTypes.Email)?.Value;
}