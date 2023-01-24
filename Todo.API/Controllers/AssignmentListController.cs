using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.interfaces;
using Todo.API.Model.AssignmentList;
using Todo.Core;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/assignmentlist")]
public class AssignmentListController:ControllerBase
{
    private readonly IAssignmentListService _assignmentListService;
    private readonly IMapper _mapper;

    public AssignmentListController(IAssignmentListService assignmentListService, IMapper mapper)
    {
        _assignmentListService = assignmentListService;
        _mapper = mapper;
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create(CreateAssignmentListModel assignmentListModel)
    {
        try
        {
            var assignmentListDto = _mapper.Map<AssignmentListDTO>(assignmentListModel);
            var assignmentListCreated = await _assignmentListService.Create(assignmentListDto);
            return Ok(assignmentListCreated);
        }
        catch (DomainException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
    
    [HttpDelete("delete")]
    public async Task<ActionResult> Delete( long assignmentListId )
    {
        try
        {
            await _assignmentListService.Remove(assignmentListId);
            return Ok("Ok");
        }
        catch (DomainException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
}
