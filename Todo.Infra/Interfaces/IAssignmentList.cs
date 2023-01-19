using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IAssignmentList: IBaseRepository<AssignmentList>
{
    Task<List<AssignmentList>> Get(long userId);
    Task<AssignmentList> Get(long userId, long assignmentListId );
    
}