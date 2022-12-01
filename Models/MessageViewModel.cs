using BugtrackerHF.DAL;
namespace BugtrackerHF.Models;

public class MessageViewModel
{
    // Default constructor to keep EF Core happy 
    public MessageViewModel() { }

    // Overloaded constructor for parent message
    public MessageViewModel(int senderId, int receiverId, string message)
    {
        CreatedTime = DateTime.Now;
        SenderUserId = senderId;
        ReceiverUserId = receiverId;
        Message = message;
        Viewed = false;
        ParentId = 0;
    }

    // Overloaded constructor for child message
    public MessageViewModel(int senderId, int receiverId, string message, int parentId)
    {
        CreatedTime = DateTime.Now;
        SenderUserId = senderId;
        ReceiverUserId = receiverId;
        Message = message;
        Viewed = false;
        ParentId = parentId;
    }


    public int Id { get; set; }

    // To make this message the parent, set ParentMessageId to 0
    public int ParentId { get; set; }
    public DateTime CreatedTime { get; set; }
    public int SenderUserId { get; set; }
    public int ReceiverUserId { get; set; }
    public string? Message { get; set; }
    public bool Viewed { get; set; }

    
}