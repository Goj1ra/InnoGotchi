using InnoGotchi.Application.Models;

namespace InnoGotchi.Application.Services.Interfaces
{
    public interface IPetService 
    {
        Task<PetModel> CreatePet(PetModel model);
        Task<PetModel> FeedPet(PetModel model);
        Task<PetModel> GetDrinkPet(PetModel model);
    }
}
