
using InnoGotchi.Application.Models;

namespace InnoGotchi.Application.Services.Interfaces
{
    public interface IFarmService
    {
        Task<FarmModel> CreateFarm (FarmModel model);

    }
}
