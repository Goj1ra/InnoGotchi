using InnoGotchi.Application.Models;

namespace InnoGotchi.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Register(UserModel user);

        Task<UserModel> GetUserById(int id);
        Task<UserModel> Login (UserModel user);
    }
}
