using QuestRooms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomsContext db = new RoomsContext();

            foreach(var c in db.QuestRooms)
                Console.WriteLine($"{c.Name}");
        }

    }
}
