using Todo.Domain.Entities;

namespace Todo.Infra.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Create(T obj);
    Task<T> Get(long id);
    Task<List<T>> Get();
    Task<T> Update(T obj); 
}