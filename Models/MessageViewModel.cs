namespace BugtrackerHF.Models;

public class MessageViewModel
{
    public int Id { get; set; }

    // To make this message the parent, set ParentMessageId to 0
    public int ParentMassageId { get; set; }

    public DateTime? CreatedTime { get; set; }
    public int SenderUserId { get; set; }
    public int? ReceiverUserId { get; set; }
    public string? Message { get; set; }
}