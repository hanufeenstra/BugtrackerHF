using BugtrackerHF.DAL;
namespace BugtrackerHF.Models;

public class MessageViewModel
{
    public MessageViewModel()
    {
    }

    public MessageViewModel(int createdByUserId, string message)
    {
        CreatedTime = DateTime.Now;
        CreatedByUserId = createdByUserId;
        Message = message;
        Viewed = false;
    }

    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public int CreatedByUserId { get; set; }
    public string? Message { get; set; }
    public bool Viewed { get; set; }
}