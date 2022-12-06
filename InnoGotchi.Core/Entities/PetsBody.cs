using InnoGotchi.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Entities
{
    public class PetsBody : Entity
    {
        public string Body { get; set; }
        public string Eye { get; set; }
        public string Mouth { get; set; }
        public string Nose { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
