using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IAssignmentRepository: IBaseRepository<Assignment>
{
    Task<List<Assignment>> GetAll(long userId);
    Task<List<Assignment>> SearchByDescription(long id);
    Task Remove(long userId, long assignmentId); 
    new Task<Assignment> Update(Assignment assignment); //???
    
}