using InnoGotchi.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public string Permission { get; set; }

        public List<User> Users { get; set; }
    }
}
