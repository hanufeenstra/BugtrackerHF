﻿using BugtrackerHF.Models;

namespace BugtrackerHF.DAL.Repositories;

public interface IMessageRepository
{
    void Create(MessageModel message);
    Task<MessageModel> ReadSingleByIdAsync(int messageId);
    void Update(MessageModel message);
    void Delete(int messageId);
}