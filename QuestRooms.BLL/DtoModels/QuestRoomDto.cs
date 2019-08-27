using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.BLL.DtoModels
{
    public class QuestRoomDto
    {
        public int QuestRoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public int MinAge { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public int FearLvl { get; set; }
        public int ComplexityLvl { get; set; }
        public string Telephone { get; set; }
        public string Logo { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
