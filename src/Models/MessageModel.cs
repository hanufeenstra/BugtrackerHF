namespace BugtrackerHF.src.Models;

public class MessageModel
{
    public MessageModel()
    {
    }

    public MessageModel(int createdByUserId, string message)
    {
        CreatedTime = DateTime.Now;
        CreatedByUserId = createdByUserId;
        Message = message;
    }

    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public int CreatedByUserId { get; set; }
    public string? Message { get; set; }
}