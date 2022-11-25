using InnoGotchi.Application.Models.Base;

namespace InnoGotchi.Application.Models
{
    public class PetsBodyModel : BaseModel
    {
        public string Body { get; set; }
        public string Eye { get; set; }
        public string Mouth { get; set; }
        public string Nose { get; set; }
    }
}
