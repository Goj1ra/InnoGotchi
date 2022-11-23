using InnoGotchi.Application.Models.Base;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public FarmModel MyOwnFarm { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}
