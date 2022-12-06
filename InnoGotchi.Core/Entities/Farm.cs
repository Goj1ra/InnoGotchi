using InnoGotchi.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoGotchi.Core.Entities
{
    public class Farm : Entity
    {
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public List<Pet> Pets { get; set; }
        public Farm()
        {
            Pets = new List<Pet>();
        }
    }
}
