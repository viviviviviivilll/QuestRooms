using AutoMapper;
using QuestRooms.BLL.DtoModels;
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
    public class QuestRoomService : IQuestRoomService
    {

        private readonly IRepository<QuestRoom> questRoomRepos;
        private readonly IMapper mapper;
        public QuestRoomService(IRepository<QuestRoom> _repos, IMapper _mapper)
        {
            questRoomRepos = _repos;
            mapper = _mapper;
        }
        public ICollection<QuestRoomDto> GetAllQuestRooms()
        {
            var questRooms = questRoomRepos.GetAll();
            return mapper.Map<IEnumerable<QuestRoom>, ICollection<QuestRoomDto>>(questRooms);
        }
    }
}
