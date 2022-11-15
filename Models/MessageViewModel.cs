using BugtrackerHF.DAL;
namespace BugtrackerHF.Models;

public interface IMessageViewModel
{
    int Id { get; set; }
    int ParentId { get; }
    DateTime CreatedTime { get; }
    int SenderUserId { get; }
    int ReceiverUserId { get; }
    string Message { get; }
    bool Viewed { get; set; }
}

public class MessageViewModel : IMessageViewModel
{

    // Constructor for parent message
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
    public int ParentId { get; }
    public DateTime CreatedTime { get; }
    public int SenderUserId { get; }
    public int ReceiverUserId { get; }
    public string Message { get;  }
    public bool Viewed { get; set; }

    
}