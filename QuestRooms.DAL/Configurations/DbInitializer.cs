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

            context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Countries.sql"));
            context.Database.ExecuteSqlCommand(ReadFromFile(dirPath + "/MockData/Countries.sql"));
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
