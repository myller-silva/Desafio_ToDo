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
            x => x.Type == "Id"); // o que tá acontecendo aqui? o que é claim
        if (claim==null)
            return 0;
        return string.IsNullOrWhiteSpace(claim.Value) ? 0 : long.Parse(claim.Value);
    }


    public async Task<AssignmentDTO> Update(AssignmentDTO assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.Get(assignmentDto.Id);
        if (assignmentExists == null)
            throw new DomainException("Nao existe nenhuma Task com o Id informado!");
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();
        var assignmentUpdated = await _assignmentRepository.Update(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentUpdated);
    }

    public Task<AssignmentDTO> Create(AssignmentDTO obj)
    {
        return Create(_mapper.Map<CreateAssignmentDTO>(obj));
    }

    public async Task<AssignmentDTO> Create(CreateAssignmentDTO obj)
    {
        var assignment = _mapper.Map<Assignment>(obj);
        assignment.UserId = GetUserId();
        // if (!await ValidateAssignment(assignment)) return null; ??
        var assignmentCreated = await _assignmentRepository.Create(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentCreated);
    }
    public Task<AssignmentDTO> Create(long userId, AssignmentDTO assignmentDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentDTO>> GetAll(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentDTO>> GetAllFromAssigmentList(long userId, long assigmentListId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentDTO>> SearchByDescription(long userId, string description)
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentDTO> Get(UserDTO user, long id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(long userId, long assignmentId)
    {
        throw new NotImplementedException();
    }
}