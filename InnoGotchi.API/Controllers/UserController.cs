using InnoGotchi.API.Attributes;
using InnoGotchi.API.Controllers.Base;
using InnoGotchi.API.Mapper;
using InnoGotchi.API.ViewModels;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Models.Base;
using InnoGotchi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InnoGotchi.API.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] UserLoginViewModel model)
        {
            try
            {
                var user = ApiMapper.Mapper.Map<UserModel>(model);
                var response = _userService.Login(user).Result;
                var apiResult = ApiResult<UserModel>.Success(response);
                return Ok(apiResult);
            }
            catch(Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }   
            
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] UserRegisterViewModel model)
        {
            try
            {
                var user = ApiMapper.Mapper.Map<UserModel>(model);
                var response = await _userService.Register(user);
                var apiResult = ApiResult<UserModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUser (int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                var apiResult = ApiResult<UserModel>.Success(user);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }
    }
}
