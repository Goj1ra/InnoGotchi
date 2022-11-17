using InnoGotchi.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Entities
{
    public class User : Entity
    { 
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] Avatar { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
        public Farm MyOwnFarm { get; set; }


    }
}
