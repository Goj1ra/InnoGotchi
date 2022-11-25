using InnoGotchi.Application.Models;

namespace InnoGotchi.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Register(UserModel user);
        Task<UserModel> Login (UserModel user);
        Task<UserModel> UpdateUserCredentials(UserModel user);
    }
}
