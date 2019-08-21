using AutoMapper;
using QuestRooms.BLL.DtoModels;
using QuestRooms.BLL.Mapping;
using QuestRooms.BLL.Services.Abstraction;
using QuestRooms.DAL.Entities;
using QuestRooms.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.BLL.Services.Implementation
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> cityRepos;
        private readonly IMapper mapper;
        public CityService(IRepository<City> _repos, IMapper _mapper)
        {
            cityRepos = _repos;
            mapper = _mapper;
        }
        public ICollection<CityDto> GetAllCities()
        {
            var cities = cityRepos.GetAll();
            return mapper.Map<IEnumerable<City>, ICollection<CityDto>>(cities);
        }
    }
}
