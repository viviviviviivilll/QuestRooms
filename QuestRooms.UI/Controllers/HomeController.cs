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
            var info = new ViewInformation
            {
                Rooms = questRoomService.GetAllQuestRooms().ToList(),
                CountOfItems = questRoomService.GetAllQuestRooms().ToList().Count(),
                CardBackgrounds = new List<string>() { "#8e44ad", "#e74c3c", "#2c3e50", "#5352ed", "#8e44ad", "#5352ed", "#e74c3c", "#2c3e50", "#5352ed", "#8e44ad" },
                PageNumber = 1
            };
            return View(info);
        }
        public string GetRoomInfo(int RoomId)
        {
            return "hello" + RoomId;
        }
    }

    public class ViewInformation
    {
        public List<BLL.DtoModels.QuestRoomDto> Rooms { get; set; }
        public int PageNumber { get; set; }
        public int CountOfItems { get; set; }
        public List<string> CardBackgrounds { get; set; }
    }
}