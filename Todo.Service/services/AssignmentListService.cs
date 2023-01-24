using AutoMapper;
using Microsoft.AspNetCore.Http;
using Service.DTO;
using Service.interfaces;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces;

namespace Service.services;

public class AssignmentListService: IAssignmentListService
{
    private readonly IMapper _mapper;
    private readonly IAssignmentListRepository _assignmentListRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AssignmentListService(IMapper mapper, IAssignmentListRepository assignmentListRepository, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _assignmentListRepository = assignmentListRepository;
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
    
    public Task<AssignmentListDTO> Update(AssignmentListDTO obj)
    {
        throw new NotImplementedException();
    }

    public async Task<AssignmentListDTO> Create(AssignmentListDTO obj)
    {
        obj.UserId = GetUserId();
        var assignmentList = _mapper.Map<AssignmentList>(obj);
        var assignmentListCreated = await _assignmentListRepository.Create(assignmentList);
        return _mapper.Map<AssignmentListDTO>(assignmentListCreated);
    }

    public Task<AssignmentListDTO> Get(long id)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(long id)
    {
        await _assignmentListRepository.Remove( GetUserId(), id );
    }

    public Task<List<AssignmentListDTO>> Get()
    {
        throw new NotImplementedException();
    }
}