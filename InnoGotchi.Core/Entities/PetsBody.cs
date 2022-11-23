using InnoGotchi.Core.Entities.Base;

namespace InnoGotchi.Core.Entities
{
    public class PetsBody : Entity
    {
        public byte[] Body { get; set; }
        public byte[] Eye { get; set; }
        public byte[] Mouth { get; set; }
        public byte[] Nose { get; set; }
    }
}
