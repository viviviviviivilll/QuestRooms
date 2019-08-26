using QuestRooms.BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IQuestRoomService questRoomService;
        public HomeController(IQuestRoomService _questRoomService)
        {
            questRoomService = _questRoomService;
        }
        public ActionResult Index()
        {
            return View(questRoomService.GetAllQuestRooms().ToList());
        }
    }
}