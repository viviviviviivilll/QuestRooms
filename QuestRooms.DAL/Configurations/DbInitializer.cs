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
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);

            context.Database.ExecuteSqlCommand(ReadFromFile(@"C:\Users\Boiichuk\source\repos\QuestRooms\QuestRooms.DAL\MockData\Cities.sql"));
            //context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Countries.sql"));
            //context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Companies.sql"));
            //context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Streets.sql"));
            //context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Cities.sql"));
            //context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Addresses.sql"));
            //context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/QuestRooms.sql"));
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
