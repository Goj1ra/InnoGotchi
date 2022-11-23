using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.API.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
