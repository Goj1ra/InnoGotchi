using InnoGotchi.Application.Models.Base;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Models
{
    public class PetModel : BaseModel
    {
        public string Name { get; set; }
        public DateTime BornDate = DateTime.UtcNow;
        public string Age { get; set; }
        public int HungerLevel { get; set; }
        public int ThirstyLevel { get; set; }
        public int HapinessDaysCount { get; set; }
        public string Body { get; set; }
        public string Eye { get; set; }
        public string Mouth { get; set; }
        public string Nose { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int FarmId { get; set; }
        public FarmModel Farm { get; set; }
        public int PetsBodyId { get; set; }
        public PetsBodyModel PetsBody { get; set; }
    }
}
