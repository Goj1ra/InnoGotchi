using InnoGotchi.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Entities
{
    public class Pet : Entity
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string HungerLevel { get; set; }
        public string ThirstyLevel { get; set; }
        public string HapinessDaysCount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int PetsBodyId { get; set; }
        public PetsBody Body { get; set; }

    }
}
