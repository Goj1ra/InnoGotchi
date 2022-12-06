using InnoGotchi.API.Controllers.Base;
using InnoGotchi.API.Mapper;
using InnoGotchi.API.ViewModels;
using InnoGotchi.Application.Models;
using InnoGotchi.Application.Models.Base;
using InnoGotchi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InnoGotchi.API.Controllers
{
    [Authorize]
    public class FarmController : ApiController
    {
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(FarmViewModel farmViewModel)
        {
            try
            {
                var farm = ApiMapper.Mapper.Map<FarmModel>(farmViewModel);
                var response = await _farmService.CreateFarm(farm);
                var apiResult = ApiResult<FarmModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }

        }
    }
}
