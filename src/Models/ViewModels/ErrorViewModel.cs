namespace BugtrackerHF.src.Models.ViewModels
{
    public class ErrorViewModel : IErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public interface IErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId { get; }
    }
}