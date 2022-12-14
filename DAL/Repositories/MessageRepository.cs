using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<MessageViewModel> ReadSingleByIdAsync(int messageId)
    {
        var message = await _context.MessageViewModel
            .SingleOrDefaultAsync(m => m.Id == messageId);

        return message;
    }

    public void Update(MessageViewModel messageViewModel)
    {
    }

    public void Delete(int messageId)
    {

    }


}