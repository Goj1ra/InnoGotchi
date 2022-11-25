using InnoGotchi.Application.Mapper;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Services.Interfaces;
using InnoGotchi.Core.Entities;
using InnoGotchi.Core.Repositories.Base;

namespace InnoGotchi.Application.Services.Implementations
{
    public class FarmService : IFarmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Farm> _farmRepository;
        private readonly IRepository<User> _userRepository;

        public FarmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _farmRepository = unitOfWork.GetRepository<Farm>();
            _userRepository = unitOfWork.GetRepository<User>();
        }


        public async Task<FarmModel> CreateFarm(FarmModel model)
        {
            var user = _userRepository.GetFirstOrDefault(
                predicate: x => x.Name == model.User.Name);
            var farm = ApplicationMapper.Mapper.Map<Farm>(model);
            farm.User = user;
            await _farmRepository.InsertAsync(farm);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
    }
}
