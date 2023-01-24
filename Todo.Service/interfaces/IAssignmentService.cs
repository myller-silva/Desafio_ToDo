using Service.DTO;

namespace Service.interfaces;

public interface IAssignmentService: IBaseService<AssignmentDTO>
{
    // CRUD : CREATE / READ / UPDATE / DELETE

    // Task<AssignmentDTO> Create(CreateAssignmentDTO assignmentDto);

    // Task<AssignmentDTO> Create( long userId, AssignmentDTO assignmentDto);
    Task<List<AssignmentDTO>> GetAll(long userId);
    Task<List<AssignmentDTO>> GetAllFromAssigmentList(long userId, long assigmentListId);
    Task<List<AssignmentDTO>> SearchByDescription(long userId, string description);
    Task Remove(long id);

    // Task Remove(long userId, long assignmentId);

}