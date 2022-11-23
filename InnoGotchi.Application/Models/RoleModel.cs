using InnoGotchi.Application.Models.Base;
using InnoGotchi.Core.Entities;

namespace InnoGotchi.Application.Models
{
    public class RoleModel : BaseModel
    {
        public string Name { get; set; }

        public string Permission { get; set; }

        public List<User> Users { get; set; }
    }
}
