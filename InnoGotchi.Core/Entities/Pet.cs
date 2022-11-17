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
        public byte[] Body { get; set; }
        public byte[] Eye { get; set; }
        public byte[] Mouth { get; set; }
        public byte[] Nose { get; set; }
        public string Age { get; set; }
        public string HungerLevel { get; set; }
        public string ThirstyLevel { get; set; }
        public string HapinessDaysCount { get; set; }
        public User User { get; set; }
        public Farm Farm { get; set; }

    }
}
