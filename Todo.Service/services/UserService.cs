using AutoMapper;
using Service.DTO;
using Service.interfaces;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces;

namespace Service.services;


public class UserService: IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    
    
    public UserService(IMapper mapper, IUserRepository userRepository) 
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.Get(userDto.Id);
        if (userExists == null)
            throw new DomainException("Nao existe nenhum usuario com o Id informado!");
        var user = _mapper.Map<User>(userDto);
        user.Validate();
        var userUpdated = await _userRepository.Update(user);
        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);
        if (userExists != null)
            throw new DomainException("Já existe usuario cadastrado com o email informado.");
        var user = _mapper.Map<User>(userDto);
        user.Validate();
        var userCreated = await _userRepository.Create(user);
        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task Remove(long userId)
    {
        var user = await Get(userId);
        if (user == null)
        {
            throw new DomainException("Nao existe User com o Id informado");
        }
        await _userRepository.Remove(userId);
    }

    public async Task<UserDTO> Get(long userId)
    {
        var user = await _userRepository.Get(userId);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> Get()
    {
        var users = await _userRepository.Get(); 
        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<List<UserDTO>> SearchByName(string name)
    {
        var users = await _userRepository.SearchByName(name);
        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var users = await _userRepository.SearchByEmail(email);
        return _mapper.Map<List<UserDTO>>(users);
    }
}

