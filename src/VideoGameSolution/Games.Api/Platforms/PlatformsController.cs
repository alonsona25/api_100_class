using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Games.Api.Platforms;

[ApiController]
public class PlatformsController : ControllerBase
{
    // POST /platforms
    [HttpPost("/platforms")]
    public async Task<ActionResult> AddPlatformAsync([FromBody] PlatformCreateRequest request)
    {
        // Step 1 Make Sure it's valid
        // Step 1.2 - Check for uniqueness
        // Step 2 ??? Save it somewhere...
        // Step 3 PROFIT (send them the response
        var response = new PlatformDetailsResponse
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Created = DateTimeOffset.UtcNow
        };
        
        return Ok(response);
    }
}

public record PlatformCreateRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}

public record PlatformDetailsResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required  DateTimeOffset Created { get; set; }
}