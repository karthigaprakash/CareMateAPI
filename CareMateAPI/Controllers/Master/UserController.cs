namespace CareMateAPI.Controllers;

public class UserController(UserRepository repository) : BaseController
{
    [HttpGet("get-users")]
    public async Task<IActionResult> GetUsers()
    {
        var response = await repository.GetUsers();

        return Ok(response);
    }

    [HttpGet("get-user-by-Id/{userId}")]
    public async Task<IActionResult> GetUserById(int? userId)
    {
        var response = await repository.GetUserById(userId);

        return Ok(response);
    }

    [HttpPost("save")]
    public async Task<IActionResult> Save([FromForm] User user)
    {
        var response = await repository.SaveOrUpdate(user);

        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromForm] User user)
    {
        var response = await repository.SaveOrUpdate(user);

        return Ok(response);
    }

    [HttpPost("update-role-for-user")]
    public async Task<IActionResult> UpdateRoleForUser(int? userId, int? roleId)
    {
        var response = await repository.UpdateRoleForUser(userId, roleId);

        return Ok(response);
    }
}