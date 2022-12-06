using InnoGotchi.Application.Mapper;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Services.Interfaces;
using InnoGotchi.Core.Entities;
using InnoGotchi.Core.Repositories.Base;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InnoGotchi.Application.Services.Implementations
{
    public class FarmService : IFarmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Farm> _farmRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public FarmService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _farmRepository = unitOfWork.GetRepository<Farm>();
            _userRepository = unitOfWork.GetRepository<User>();
        }


        public async Task<FarmModel> CreateFarm(FarmModel model)
        {
            var user = GetCurrentUser();
            model.Id = user.Id;
            model.UserId = user.Id;
            user.FarmId = model.Id;
            var farm  = ApplicationMapper.Mapper.Map<Farm>(model);
            _userRepository.Update(user);
            await _farmRepository.InsertAsync(farm);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }

        private User GetCurrentUser()
        {
            var claims = _contextAccessor.HttpContext.User;
            var email = claims.FindFirst(ClaimTypes.Email).Value;
            return _userRepository.GetFirstOrDefault(
                predicate: user => user.Email == email);
        } 
    }
}
