using InnoGotchi.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Entities
{
    public class Farm : Entity
    {
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
