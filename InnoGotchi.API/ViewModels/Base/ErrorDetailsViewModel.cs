using System.Text.Json;

namespace InnoGotchi.API.ViewModels.Base
{
    public class ErrorDetailsViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => 
            JsonSerializer.Serialize(this);
    }
}
