using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.API.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string LastName { get; set; }
       
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
