using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Entities;

namespace Todo.API.Controllers;

[ApiController]
[Route("/api/assignment")]
public class AssignmentController: ControllerBase
{
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> Create(Assignment assignment)
    {
        return Ok(assignment);
    }
    
    
}