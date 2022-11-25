using InnoGotchi.Application.Models.Base;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Models
{
    public class PetModel : BaseModel
    {
        public string Name { get; set; }
        
        public DateTime BornDate  = DateTime.UtcNow;
        public DateTime Age { get; set; }
        public string HungerLevel { get; set; }
        public string ThirstyLevel { get; set; }
        public DateTime HapinessDaysCount { get; set; }
        public UserModel User { get; set; }
        public FarmModel Farm { get; set; }
        public PetsBodyModel Body { get; set; }
    }
}
