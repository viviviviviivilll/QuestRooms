using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Name { get; set; }
        public virtual QuestRoom Room { get; set; }
    }
}
