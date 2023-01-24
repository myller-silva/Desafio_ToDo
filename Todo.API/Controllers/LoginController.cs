using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Auth;
using Service.interfaces;
using Todo.Core;

namespace Todo.API.Controllers;

[ApiController]
[Route("auth")]
public class LoginController:ControllerBase
{
    private readonly IAuthService _authService; 

    public LoginController(IAuthService authService)
    {
        _authService = authService; 
    }

    
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDTO userInput)
    {
        try
        {
            var result = await _authService.Register(userInput);
            return Ok(result) ;
        }
        catch (DomainException ex)
        {
            return BadRequest("Erro de dominio: " + ex.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Erro interno: " + e.Message);
        }
    }

    [HttpPost("login")] 
    public async Task<ActionResult> Login(LoginDTO userInput)
    {
        var userDto = new LoginDTO(
            email: userInput.Email,
            password: userInput.Password);
        var token = await _authService.Login(userDto);
        return Ok(token); 
    }
}
