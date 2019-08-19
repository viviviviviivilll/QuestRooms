namespace QuestRooms.DAL
{
    using QuestRooms.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RoomsContext : DbContext
    {
        public RoomsContext()
            : base("name=RoomsContext")
        {
        }
        public DbSet<Street> Streets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<QuestRoom> QuestRooms { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}