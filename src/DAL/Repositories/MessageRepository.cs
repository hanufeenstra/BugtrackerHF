using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Repositories;

public class MessageRepository : GenericRepository<MessageModel>, IMessageRepository
{
    public MessageRepository(BugtrackerHFContext context)
        :base(context)
    {
    }
}