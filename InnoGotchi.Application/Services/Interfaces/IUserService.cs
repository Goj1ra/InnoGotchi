using InnoGotchi.Application.Models;
using InnoGotchi.Shared.Paging;

namespace InnoGotchi.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Register(UserModel user);
        Task<UserModel> Login (UserModel user);
        Task<UserModel> UpdateUserCredentials(UserModel user);
        Task<IEnumerable<UserModel>> GetUsers(int startIndex, int endIndex);
        Task<string> ChangePassword(string oldPassword, string newPassword);
    }
}
