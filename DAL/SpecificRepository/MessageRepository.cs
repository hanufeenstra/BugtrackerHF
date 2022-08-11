using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.DAL.UnitOfWork;
using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.SpecificRepository;

//public class MessageRepository : GenericRepository<MessageViewModel>//, IMessageRepository
//{
    //public MessageRepository(IUnitOfWork unitOfWork)
    //    : base(unitOfWork)
    //{
    //}

    //public MessageRepository(BugtrackerHFContext context)
    //    : base(context)
    //{
    //}

    //public void SendMessage(MessageViewModel messageViewModel)
    //{
    //}

    //public List<MessageViewModel> GetAllConversationsForUser(int userId)
    //{
    //    var messageViewModel = _context.MessageViewModel.ToList(m => m. = userId);


    //    return messageViewModel.ToList();
    //}

    //public int GetNewMessagesCount(int userId)
    //{
    //    return 0;
    //}

    //public void SetMessageViewed(int messageId)
    //{
    //    var messageViewModel = _context.MessageViewModel.Find(messageId);
    //}
//}