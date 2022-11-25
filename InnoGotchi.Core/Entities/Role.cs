using InnoGotchi.Core.Entities.Base;
namespace InnoGotchi.Core.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public string Permission { get; set; }

        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
