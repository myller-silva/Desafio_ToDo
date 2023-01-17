using Microsoft.AspNetCore.Mvc;
using Todo.API.Model.User;
using Todo.Core;
using Todo.Domain.Entities;
using Todo.Services.DTO;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController: ControllerBase
{
    // private readonly IUserService _userService;
    // private readonly IMapper _mapper; //pesquisar sobre AutoMapper e o IMapper
    //
    // public UserController(IUserService userService, IMapper mapper)
    // {
    //     _userService = userService;
    //     _mapper = mapper;
    // }  

    [HttpPost]
    [Route("/create")]
    public async Task<ActionResult> Create([FromBody] CreateUserModel userModel)
    {
        try
        {
            var user = new User
            (
                name: userModel.Name,
                email: userModel.Email,
                password: userModel.Password
            );
            user.Validate();
            return Ok(user);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.InnerException);
        }
    }
    
    [HttpPut]
    [Route("/update")]
    public async Task<ActionResult> Update([FromBody] UpdateUserModel userModel)
    {
        return Ok( userModel );
    }

    [HttpDelete]
    [Route("/delete/{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        return Ok( "nao foi deletado pq nao foi implementado" );
    }

    [HttpGet]
    [Route("/get/{id}")]
    public async Task<ActionResult> Get(long id)
    {
        return Ok( id );
    }


}