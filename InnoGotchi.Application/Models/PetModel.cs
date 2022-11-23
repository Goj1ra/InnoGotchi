using InnoGotchi.Application.Models.Base;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Models
{
    public class PetModel : BaseModel
    {
        public string Name { get; set; }
        
        public string Age { get; set; }
        public string HungerLevel { get; set; }
        public string ThirstyLevel { get; set; }
        public string HapinessDaysCount { get; set; }
        public UserModel User { get; set; }
        public FarmModel Farm { get; set; }
        public PetsBodyModel Body { get; set; }
    }
}
