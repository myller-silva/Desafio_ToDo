using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.interfaces;
using Todo.API.Model;
using Todo.Domain.Entities;

namespace Todo.API.Controllers;

[ApiController]
[Route("/api/assignment")]
public class AssignmentController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAssignmentService _assignmentService;

    public AssignmentController(IMapper mapper, IAssignmentService assignmentService)
    {
        _mapper = mapper;
        _assignmentService = assignmentService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> Create(CreateAssigmentModel assignmentModel)
    {
        var assignment = await _assignmentService.Create(_mapper.Map<AssignmentDTO>(assignmentModel));
        return Ok(assignment);
    }
}