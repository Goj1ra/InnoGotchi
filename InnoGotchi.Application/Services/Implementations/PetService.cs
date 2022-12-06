using InnoGotchi.Application.Mapper;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Services.Interfaces;
using InnoGotchi.Core.Entities;
using InnoGotchi.Core.Repositories.Base;

namespace InnoGotchi.Application.Services.Implementations
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Pet> _petRepository;
        

        public PetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _petRepository = unitOfWork.GetRepository<Pet>();
        }
        public async Task<PetModel> CreatePet(PetModel model)
        {
            model.ThirstyLevel = 0;
            model.HungerLevel = 0;
            var pet = ApplicationMapper.Mapper.Map<Pet>(model);
            await _petRepository.InsertAsync(pet);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }

        public Task<PetModel> FeedPet(PetModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PetModel> GetDrinkPet(PetModel model)
        {
            throw new NotImplementedException();
        }
    }
}
