using Service.DTO;

namespace Service.interfaces;

public interface IUserService: IBaseService<UserDTO>
{ 
    // Task<UserDTO> Update(UserDTO userDto);
    Task Remove(long userId); 
    Task<UserDTO> GetByEmail(string email);
    Task<List<UserDTO>> Get();
    Task<List<UserDTO>> SearchByName(string name);
    Task<List<UserDTO>> SearchByEmail(string email);

}
    