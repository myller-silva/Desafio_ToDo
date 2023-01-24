using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IAssignmentRepository: IBaseRepository<Assignment>
{
    Task<List<Assignment>> GetAll(long userId);
    Task<Assignment> Get(long userId, long id);
    Task<List<Assignment>> SearchByDescription(string description);
    Task Remove(long userId, long assignmentId); 
    
}