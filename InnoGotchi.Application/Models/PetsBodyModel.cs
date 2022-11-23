using InnoGotchi.Application.Models.Base;

namespace InnoGotchi.Application.Models
{
    public class PetsBodyModel : BaseModel
    {
        public byte[] Body { get; set; }
        public byte[] Eye { get; set; }
        public byte[] Mouth { get; set; }
        public byte[] Nose { get; set; }
    }
}
