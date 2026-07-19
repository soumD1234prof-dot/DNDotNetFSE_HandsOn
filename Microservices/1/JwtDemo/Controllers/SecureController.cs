using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    [Authorize]
    [HttpGet("data")]
    public IActionResult GetSecureData()
    {
        var username = User.Identity?.Name;
        return Ok(new { Message = $"Hello {username}, this is protected data." });
    }
}