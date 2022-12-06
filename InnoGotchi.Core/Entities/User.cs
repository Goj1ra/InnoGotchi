using InnoGotchi.Core.Entities.Base;

namespace InnoGotchi.Core.Entities
{
    public class User : Entity
    { 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int FarmId { get; set; }
        public Farm MyOwnFarm { get; set; }
        public int userStatisticsId { get; set; }
        public UserStatistics Statistics { get; set; }
        public List<Pet> Pets { get; set; }
        public User()
        {
            Pets = new List<Pet>();
        }


    }
}
