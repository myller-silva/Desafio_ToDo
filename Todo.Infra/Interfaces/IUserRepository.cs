using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IUserRepository: IBaseRepository<User>
{
    Task Remove(long id);
    Task<User> GetByEmail(string email);
    Task<List<User>> SearchByEmail(string email);
    Task<List<User>> SearchByName(string name);
}