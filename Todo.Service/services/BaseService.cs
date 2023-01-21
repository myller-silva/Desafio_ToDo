using Service.DTO;
using Service.interfaces;

namespace Service.services;

public class BaseService: IBaseService<BaseDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public Task<BaseDTO> Update(BaseDTO obj)
    {
        var userExists = await _userRepository.Get(userDto.Id);
        if (userExists == null)
            throw new DomainException("Nao existe nenhum usuario com o Id informado!");
        var user = _mapper.Map<User>(userDto);
        user.Validate();
        var userUpdated = await _userRepository.Update(user);
        return _mapper.Map<UserDTO>(userUpdated);
        throw new NotImplementedException();
    }

    public Task<BaseDTO> Create(BaseDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);
        if (userExists != null)
            throw new DomainException("Já existe usuario cadastrado com o email informado.");
        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userCreated = await _userRepository.Create(user);
        return _mapper.Map<UserDTO>(userCreated);
    }
}