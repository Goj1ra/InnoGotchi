
using InnoGotchi.Application.Models.Base;

namespace InnoGotchi.Application.Models
{
    public class UserStatisticsModel : BaseModel
    {
        public int AlivePets { get; set; }
        public int DeadPets { get; set; }
        public string AverageFeeding { get; set; }
        public string AveregeThirst { get; set; }
        public string AveregePetsAge { get; set; }
    }
}
