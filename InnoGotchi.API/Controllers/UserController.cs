using InnoGotchi.API.Controllers.Base;
using InnoGotchi.API.Mapper;
using InnoGotchi.API.ViewModels;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Models.Base;
using InnoGotchi.Application.Services.Interfaces;
using InnoGotchi.Shared.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InnoGotchi.API.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
        {
            try
            {
                var user = ApiMapper.Mapper.Map<UserModel>(model);
                var response = await _userService.Login(user);
                var apiResult = ApiResult<UserModel>.Success(response);
                return Ok(apiResult);
            }
            catch(Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }   
            
        }

        [AllowAnonymous]
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromForm] UserUpdateViewModel userUpdateViewModel)
        {
            try
            {
                string pathToFile = " ";
                if(userUpdateViewModel.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    pathToFile = Path.Combine(path, userUpdateViewModel.files.FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using(FileStream fileStream = System.IO.File.Create(path + userUpdateViewModel.files.FileName))
                    {
                        userUpdateViewModel.files.CopyTo(fileStream);
                        fileStream.Flush(); 
                    }
                }
                var user = ApiMapper.Mapper.Map<UserModel>(userUpdateViewModel);
                user.AvatarPath = pathToFile;
                var response = await _userService.UpdateUserCredentials(user);
                var apiResult = ApiResult<UserModel>.Success(response);
                return Ok(apiResult);
            }
            catch(Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(int startIndex, int endIndex)
        {
            try
            {
                var requestedUsers = await _userService.GetUsers(startIndex, endIndex);
                var apiResult = ApiResult<IEnumerable<UserModel>>.Success(requestedUsers);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<List<UserModel>>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [HttpPost("password")]
        public async Task<IActionResult> ChangePassword(UserPasswordViewModel userPassword)
        {
            try
            {
                if(userPassword.NewPassword == userPassword.ConfirmPassword)
                {
                    var response = await _userService.ChangePassword(userPassword.OldPassword, userPassword.NewPassword);
                    var apiResultOk = ApiResult<string>.Success(response);
                    return Ok(apiResultOk);
                }
                var apiResultBad = ApiResult<string>.Failure(new[] { "Password isn't match" });
                return BadRequest(apiResultBad);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<string>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }
    }
}
