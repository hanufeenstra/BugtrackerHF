namespace BugtrackerHF.Models;

public interface IMessageService
{
    void SendMessage(MessageViewModel messageModel);
    List<MessageViewModel> GetAllConversationsForUser(int userId);
    int GetNewMessagesCount(int userId);
    void SetMessageViewed(int messageId);
}