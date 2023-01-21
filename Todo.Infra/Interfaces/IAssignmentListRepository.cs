using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IAssignmentListRepository: IBaseRepository<AssignmentList>
{
    Task<AssignmentList> Get(long userId, long assignmentListId );
    Task Remove(long userId, long assignmentId);
}