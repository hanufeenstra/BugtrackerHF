using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly BugtrackerHFContext _context;
    public MessageRepository(BugtrackerHFContext context)
    {
        _context = context;
    }

    public void Create(MessageViewModel message)
    {
        _context.Add(message);
        _context.SaveChanges();
    }

    public MessageViewModel ReadSingleById(int messageId)
    {
        var message = _context.MessageViewModel.Find(messageId);
        return message;
    }

    public void Update(MessageViewModel messageViewModel)
    {
    }

    public void Delete(int messageId)
    {

    }


}