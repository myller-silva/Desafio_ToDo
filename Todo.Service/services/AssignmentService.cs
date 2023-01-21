using AutoMapper;
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

    public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<AssignmentDTO> Update(AssignmentDTO assignmentDto)
    {
        var assignmentExists = await _assignmentRepository.Get(assignmentDto.Id);
        if (assignmentExists == null)
            throw new DomainException("Nao existe nenhum usuario com o Id informado!");
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();
        var assignmentUpdated = await _assignmentRepository.Update(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentUpdated);
    }

    public async Task<AssignmentDTO> Create(AssignmentDTO assignmentDto)
    {
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        var assignmentCreated = await _assignmentRepository.Create(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentCreated);
    }

    public Task<AssignmentDTO> Create(UserDTO userDto, AssignmentDTO assignmentDto)
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