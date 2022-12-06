using InnoGotchi.Application.Mapper;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Services.Interfaces;
using InnoGotchi.Core.Entities;
using InnoGotchi.Core.Repositories.Base;
using InnoGotchi.Shared.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace InnoGotchi.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public async Task<UserModel> Login(UserModel userModel)
        {
            var user = Authenticate(userModel).Result;

            userModel.Token = Generate(user);

            return userModel;
        }

        public async Task<UserModel> Register(UserModel userModel)
        {
            var user = ApplicationMapper.Mapper.Map<User>(userModel);
            if(!_userRepository.Exists(user => user.Email == userModel.Email))
            {
                user.PasswordHash = BCryptNet.HashPassword(userModel.Password);
                user.PasswordSalt = BCryptNet.GenerateSalt();
                await _userRepository.InsertAsync(user);
                await _unitOfWork.SaveChangesAsync();
                return userModel;
            }
            return null;
        }

        public async Task<UserModel> UpdateUserCredentials(UserModel userModel)
        {
            var currentUser = GetCurrentUser();
            currentUser.Avatar = userModel.AvatarPath;
            currentUser.Name = userModel.Name;
            currentUser.LastName = userModel.LastName;
            _userRepository.Update(currentUser);
            await _unitOfWork.SaveChangesAsync();
            return userModel;
        }

        public async Task<string> ChangePassword(string oldPassword, string newPassword)
        {
            var hash = BCryptNet.HashPassword(newPassword);
            var salt = BCryptNet.GenerateSalt();
            var currentUser = GetCurrentUser();
            var isPasswordCorrect = BCryptNet.Verify(oldPassword, currentUser.PasswordHash);
            if (isPasswordCorrect)
            {
                currentUser.PasswordHash = hash;
                currentUser.PasswordSalt = salt;
                _userRepository.Update(currentUser);
                await _unitOfWork.SaveChangesAsync();
                return "Password successfully updated!";
            }
            return "Wrong password";
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int startIndex, int endIndex)
        {
           var users = await _userRepository.GetAllAsync(
               predicate: user => user.Id >= startIndex && user.Id <= endIndex);
           
            var userModels = ApplicationMapper.Mapper.Map<List<UserModel>>(users);
            return userModels;
        }

        private User GetCurrentUser()
        {
            var claims = _contextAccessor.HttpContext.User;
            var email = claims.FindFirst(ClaimTypes.Email).Value;
            return _userRepository.GetFirstOrDefault(
                predicate: x => x.Email == email);
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var token = new JwtSecurityToken
            (
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
               expires: DateTime.UtcNow.AddDays(7),
               signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private async Task<User> Authenticate(UserModel userModel)
        {
            var user = ApplicationMapper.Mapper.Map<User>(userModel);
            user = await _userRepository.GetFirstOrDefaultAsync(
                predicate: user => user.Email == userModel.Email);
            if (user == null || !BCryptNet.Verify(userModel.Password, user.PasswordHash))
                throw new Exceptions.ApplicationException("Username or password is incorrect");

            return user;
        }
    }
}
