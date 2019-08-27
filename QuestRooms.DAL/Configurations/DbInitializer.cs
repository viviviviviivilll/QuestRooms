using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Configurations
{
    public class DbInitializer : DropCreateDatabaseAlways<RoomsContext>
    {
        protected override void Seed(RoomsContext context)
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory + @"\bin\MockData\";
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "Cities.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "Countries.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "Companies.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "Streets.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "Addresses.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "QuestRooms.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(path + "Photos.sql"));
        }


        private string ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
