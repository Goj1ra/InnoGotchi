using InnoGotchi.API.ViewModels.Base;

namespace InnoGotchi.API.ViewModels
{
    public class UserUpdateViewModel : BaseViewModel
    {
        public IFormFile files { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
