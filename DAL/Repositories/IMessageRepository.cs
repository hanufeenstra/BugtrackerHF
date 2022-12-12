using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IMessageRepository
{
    // CRUD operations for MessageViewModel

    void Create(MessageViewModel message);
    MessageViewModel ReadSingleById(int messageId);
    void Update(MessageViewModel messageViewModel);
    void Delete(int messageId);

}