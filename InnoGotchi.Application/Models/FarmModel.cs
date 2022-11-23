using InnoGotchi.Application.Models.Base;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Models
{
    public class FarmModel : BaseModel
    {
        public string Name { get; set; }
        public UserModel User { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}
