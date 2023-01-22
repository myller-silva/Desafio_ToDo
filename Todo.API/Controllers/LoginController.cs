using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Auth;
using Service.interfaces;

namespace Todo.API.Controllers;

[ApiController]
[Route("auth")]
public class LoginController:ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public LoginController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDTO userInput)
    {
        var result = await _authService.Register(userInput);
        return Ok(result) ;
    }

    [HttpPost("login")] 
    public async Task<ActionResult> Login(UserInput userInput)
    {
        var userDto = new LoginDTO(
            email: userInput.Email,
            password: userInput.Password);
        var token = await _authService.Login(userDto);
        return Ok(token); 
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