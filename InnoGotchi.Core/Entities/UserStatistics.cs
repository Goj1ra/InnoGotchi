using InnoGotchi.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Entities
{
    public class UserStatistics : Entity
    {
        public int AlivePets { get; set; }
        public int DeadPets { get; set; }
        public string AverageFeeding { get; set; }
        public string AveregeThirst { get; set; }
        public string AveregePetsAge { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
