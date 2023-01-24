using AutoMapper;
using Microsoft.AspNetCore.Http;
using Service.DTO;
using Service.interfaces;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces;

namespace Service.services;

public class AssignmentService: IAssignmentService
{
    private readonly IMapper _mapper;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    private long GetUserId()
    {
        var claim = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(
            x => x.Type == "Id"); // o que tá acontecendo aqui? o que é claim? // obs: já entendi mais ou menos
        if (claim == null)
            throw new DomainException("A Claim é nula."); 
        return long.Parse(claim.Value); 
    } 

    public async Task<AssignmentDTO> Update(AssignmentDTO assignmentDto)
    {
        assignmentDto.UserId = GetUserId(); 
        
        var assignmentExists = await _assignmentRepository.Get(assignmentDto.Id);
        
        if (assignmentExists == null)
            throw new DomainException("Nao existe nenhuma Task com o Id informado!");
        
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate(); //obs: é necessario?
        
        var assignmentUpdated = await _assignmentRepository.Update(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentUpdated);
    }
    

    public async Task<AssignmentDTO> Get(long id)
    { 
        var assignment = await _assignmentRepository.Get(GetUserId(), id);
        return _mapper.Map<AssignmentDTO>(assignment);
    }

    public async Task<List<AssignmentDTO>> Get()
    {
        var assignments = await _assignmentRepository.GetAll(GetUserId());
        return _mapper.Map<List<AssignmentDTO>>(assignments);
    }

    public async Task<AssignmentDTO> Create(AssignmentDTO obj)
    {
        obj.UserId = GetUserId();
        var assignment = _mapper.Map<Assignment>(obj); 
        try
        {
            var assignmentCreated = await _assignmentRepository.Create(assignment);
            return _mapper.Map<AssignmentDTO>(assignmentCreated);
        }
        catch (DomainException ex)
        {  
            throw new DomainException("Erro de dominio.\n"+ ex.Message);
        }
        catch (Exception e)
        {
            throw new DomainException("Erro: "+e.Message);;
        } 
    } 
    
    
    public async Task<List<AssignmentDTO>> GetAll(long userId)
    {
        return await Get();
    }

 
    public async Task Remove(long assignmentId)
    {
        var userId = GetUserId();
        await _assignmentRepository.Remove(userId, assignmentId);
    }
    
    
    public async Task<List<AssignmentDTO>> GetAllFromAssigmentList(long userId, long assigmentListId)
    {
        throw new NotImplementedException();
    }

    
    public async Task<List<AssignmentDTO>> SearchByDescription(long userId, string description)
    {
        throw new NotImplementedException();
    }
}