using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public LoginController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("user")]
    public async Task<ActionResult> Login(UserInput userInput)
    {
        var user = await _userService.GetByEmail(userInput.Email);
        if (user == null)
            return BadRequest("Usuario nao encontrado");
        if (user.Password != userInput.Password)
        {
            return BadRequest("Senha incorreta");
        }
        return Ok(user);
    }
}

public class UserInput
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserInput(string email, string password)
    {
        Email = email;
        Password = password;
    }
}