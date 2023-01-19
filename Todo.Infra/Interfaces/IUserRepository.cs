using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User> Get(long id); 
    Task<User> GetByEmail(string email);
    Task<List<User>> SearchByEmail(string email);
    Task<List<User>> SearchByName(string name);
    Task Remove(long id);
}