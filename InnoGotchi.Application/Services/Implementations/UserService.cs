using InnoGotchi.Application.Exceptions;
using InnoGotchi.Application.Mapper;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Services.Interfaces;
using InnoGotchi.Core.Entities;
using InnoGotchi.Core.Repositories.Base;
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

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public async Task<UserModel> Login(UserModel userModel)
        {
            var user = Authenticate(userModel).Result;

            userModel.Token = Generate(user);

            return userModel;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(
                predicate: user => user.Id == id,
                selector: user => ApplicationMapper.Mapper.Map<User>(user));


            if(user == null)
            {
                throw new NotFoundException($"User with id {id} not found");
            }

            var userModel = ApplicationMapper.Mapper.Map<UserModel>(user);

            return userModel;
        }

        public async Task<UserModel> Register(UserModel userModel)
        {
            var user = ApplicationMapper.Mapper.Map<User>(userModel);
            if(!_userRepository.Exists(user => user.Email != userModel.Email))
            {
                user.PasswordHash = BCryptNet.HashPassword(userModel.Password);
                await _userRepository.InsertAsync(user);
                await _unitOfWork.SaveChangesAsync();
                return userModel;
            }
            return null;
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
