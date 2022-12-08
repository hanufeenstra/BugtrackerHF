﻿using System.Security.Claims;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly BugtrackerHFContext _context;

        public MessageController(ILogger<MessageController> logger, BugtrackerHFContext context)
        {
            _logger = logger;
            _context = context;
        }

        // POST: /api/message
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateMessage(int receiverId, string text,int parentMessageId)
        {
            var message = new MessageViewModel( );

            _context.MessageViewModel.Add(message);
             
            await _context.SaveChangesAsync();
            return CreatedAtAction("CreateMessage", message);
        }
    }
}
