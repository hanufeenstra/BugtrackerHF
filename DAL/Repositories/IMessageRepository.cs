using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IMessageRepository
{
    void Create(MessageViewModel message);
    Task<MessageViewModel> ReadSingleByIdAsync (int messageId);
    void Update(MessageViewModel messageViewModel);
    void Delete(int messageId);
}