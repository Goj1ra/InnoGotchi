using InnoGotchi.Core.Entities.Base;
using InnoGotchi.Core.Enums;

namespace InnoGotchi.Core.Entities
{
    public class Pet : Entity
    {
        public string Name { get; set; }
        public DateTime BornDate = DateTime.UtcNow;
        public DateTime Age { get; set; }
        public HungerLevel HungerLevel { get; set; }
        public ThirstyLevel thirstyLevel { get; set; }
        public int HapinessDaysCount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int PetsBodyId { get; set; }
        public PetsBody Body { get; set; }

    }
}
