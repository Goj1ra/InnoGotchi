namespace InnoGotchi.API.ViewModels
{
    public class PetCreationViewModel
    {
        public IFormFile filesEyes { get; set; }
        public IFormFile filesBodies { get; set; }
        public IFormFile filesNoses { get; set; }
        public IFormFile filesMouths{ get; set; }
        public string Name { get; set; }
    }
}
