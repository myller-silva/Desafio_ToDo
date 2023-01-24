using AutoMapper;
using Service.DTO;
using Service.interfaces;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;

namespace Service.services;

public class BaseService: IBaseService<BaseDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly TodoDbContext _context;
    public Task<BaseDTO> Update(BaseDTO obj)
    {
        throw new NotImplementedException();
    }

    public Task<BaseDTO> Create(BaseDTO obj)
    {
        throw new NotImplementedException();
    }

    public Task<BaseDTO> Get(long id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BaseDTO>> Get()
    {
        throw new NotImplementedException();
    }
}