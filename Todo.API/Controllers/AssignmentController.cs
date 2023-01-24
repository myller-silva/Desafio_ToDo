
using Todo.Core; 
using AutoMapper;
using Service.DTO;
using Service.interfaces; 
using Microsoft.AspNetCore.Mvc;
using Todo.API.Model.Assignment;
using Microsoft.AspNetCore.Authorization;

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

    
    [HttpPost("create")] 
    [Authorize] 
    public async Task<ActionResult> Create(CreateAssignmentModel assignmentModel)
    {
        try
        {
            var assignment = await _assignmentService.Create(_mapper.Map<AssignmentDTO>(assignmentModel));
            
            if (assignment == null)
                return BadRequest("A task não foi criada.");
            return Ok(assignment);
        }
        catch (DomainException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Error: " + e.Message);
        }
    }

    
    [HttpGet("get")]
    [Authorize] 
    public async Task<ActionResult> Get() //modificar para permitir pegar apenas as propria tasks 
    {
        var assignments = await _assignmentService.Get();
        if ( assignments == null )
            return BadRequest("Nenhuma task encontrada");
        return Ok(assignments); 
    }
    
    
    [HttpGet("get/{id}")]
    [Authorize] 
    public async Task<ActionResult> Get(long id) //from body?
    {
        var assignment = await _assignmentService.Get(id);
        if (assignment == null)
            return BadRequest("Nenhuma task com o id informado");
        return Ok(assignment);
    }
    

    [HttpPut("update")]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] UpdateAssignmentModel assignmentModel )
    {
        try
        {
            var assigmentDto = _mapper.Map<AssignmentDTO>(assignmentModel);
            var assignmentUpdated = await _assignmentService.Update(
                assigmentDto);
            return Ok(assignmentUpdated);
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
    

    [HttpDelete("delete/{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(long id)
    {
        try
        {
            await _assignmentService.Remove(id);
            return Ok("Task deletada com sucesso");
        }
        catch (DomainException ex)
        {
            return BadRequest("Erro de domínio: " + ex.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Erro interno: " + e.Message);
        }
    }
    
    
}

