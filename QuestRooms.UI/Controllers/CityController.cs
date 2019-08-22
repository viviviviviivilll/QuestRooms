using QuestRooms.BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        private readonly ICityService cityService;
        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }
        public string Index()
        {
            var city = cityService.GetAllCities().ToList();
            string res = "";
            foreach (var c in city)
                res += $"{c.CityId} - {c.CityName} <br>"; 
            return res;
        }// City_CityId
    }
}