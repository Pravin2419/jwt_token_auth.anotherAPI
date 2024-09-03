
using jwt_token_auth.anotherAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProtectedController : ControllerBase
{
    private readonly filedetailsContext _context;
    private readonly ILogger<ProtectedController> _logger;

    public ProtectedController(filedetailsContext context, ILogger<ProtectedController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("GET request to GetAll endpoint");
        return Ok(new { message = "This is a protected endpoint." });
    }

    [HttpPost]
    public IActionResult CreateItem([FromBody] LoginModel loginModel)
    {
        _logger.LogInformation("POST request to CreateItem endpoint with model: {Model}", loginModel);
        if (loginModel == null)
        {
            return BadRequest(new { message = "Invalid data" });
        }
        return Ok(new { Message = "Item created" });
    }
}
