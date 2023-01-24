using Service.DTO;

namespace Service.interfaces;

public interface IBaseService<T> where T: BaseDTO
{
    Task<T> Update(T obj);
    Task<T> Create(T obj);
    Task<T> Get(long id);
    Task Remove(long id);
    Task<List<T>> Get();
    
}