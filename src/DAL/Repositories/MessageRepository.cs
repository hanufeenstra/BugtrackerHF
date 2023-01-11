using BugtrackerHF.DAL.Data;
using BugtrackerHF.src.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.src.DAL.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly BugtrackerHFContext _context;
    public MessageRepository(BugtrackerHFContext context)
    {
        _context = context;
    }

    public void Create(MessageModel message)
    {
        _context.Add(message);
        _context.SaveChanges();
    }

    public async Task<MessageModel> ReadSingleByIdAsync(int messageId)
    {
        var message = await _context.MessageModel
            .SingleOrDefaultAsync(m => m.Id == messageId);

        return message;
    }

    public void Update(MessageModel messageModel)
    {
    }

    public void Delete(int messageId)
    {

    }


}