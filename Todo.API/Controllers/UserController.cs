using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.interfaces;
using Todo.API.Model.User;
using Todo.Core; 

namespace Todo.API.Controllers;
//
// [ApiController]
// [Route("/api/user")]
// public class UserController: ControllerBase
// {
//     private readonly IUserService _userService;
//     private readonly IMapper _mapper; //pesquisar sobre AutoMapper e o IMapper
//     
//     public UserController(IUserService userService, IMapper mapper)
//     {
//         _userService = userService;
//         _mapper = mapper;
//     }  
//
//     [HttpPost]
//     [Route("create")]
//     public async Task<ActionResult> Create([FromBody] CreateUserModel userModel)
//     {
//         try
//         { 
//             var userCreated = await _userService.Create(_mapper.Map<UserDTO>(userModel));
//             return Ok(userCreated);
//         }
//         catch (DomainException ex)
//         {
//             return BadRequest(ex.Errors);
//         }
//         catch (Exception e)
//         {
//             return StatusCode(500, e.InnerException);
//         }
//     }
//     
//     [HttpPut]
//     [Route("update")]
//     public async Task<ActionResult> Update([FromBody] UpdateUserModel userModel)
//     {   
//         var userUpdated = await _userService.Update(_mapper.Map<UserDTO>(userModel));
//         return Ok(userUpdated);
//     }
//
//
//     [HttpGet]
//     [Route("get/{id}")]
//     public async Task<ActionResult> Get(long id)
//     {
//         var user = await _userService.Get(id);
//         if (user == null)
//             return BadRequest("Usuario nao encontrado");
//         return Ok(user);
//     }
//
//     [HttpGet]
//     [Route("get")]
//     public async Task<ActionResult> Get()
//     {
//         var users = await _userService.Get();
//         return Ok(users);
//     }
//
//
//     [HttpDelete]
//     [Route("delete/{id}")]
//     public async Task<ActionResult> Delete(long id)
//     {
//         try
//         {
//             var user = await _userService.Get(id); 
//             if (user == null)
//                 return BadRequest("O Id informado nao pertence a nenhum usuario."); 
//             await _userService.Remove(id);
//             
//         }
//         catch (DomainException e)
//         {
//             return BadRequest("Erro de Dominio: "+e.Message);
//         }
//         catch (Exception e)
//         {
//             return StatusCode(500, e.Message);
//         }
//         return Ok("Usuario removido.");
//     }
// }
