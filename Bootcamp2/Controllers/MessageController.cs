using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootcamp2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Bootcamp2.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;
        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }
        public IActionResult Index()
        {
            string message = _messageService.GetMessage();
            return View("Index", message);
        }
    }
}