namespace QuestRooms.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migr : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Addresses", name: "CityAddress_CityId", newName: "City_CityId");
            RenameColumn(table: "dbo.Addresses", name: "CountryAddress_CountryId", newName: "Country_CountryId");
            RenameColumn(table: "dbo.Addresses", name: "StreetAddress_StreetId", newName: "Street_StreetId");
            RenameIndex(table: "dbo.Addresses", name: "IX_CityAddress_CityId", newName: "IX_City_CityId");
            RenameIndex(table: "dbo.Addresses", name: "IX_CountryAddress_CountryId", newName: "IX_Country_CountryId");
            RenameIndex(table: "dbo.Addresses", name: "IX_StreetAddress_StreetId", newName: "IX_Street_StreetId");
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Room_QuestRoomId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.QuestRooms", t => t.Room_QuestRoomId)
                .Index(t => t.Room_QuestRoomId);
            
            AddColumn("dbo.Addresses", "HouseNumber", c => c.String());
            AddColumn("dbo.QuestRooms", "Name", c => c.String());
            AddColumn("dbo.QuestRooms", "Description", c => c.String());
            AddColumn("dbo.QuestRooms", "Duration", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.QuestRooms", "MaxPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "MinPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "MinAge", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "Email", c => c.String());
            AddColumn("dbo.QuestRooms", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "FearLvl", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "ComplexityLvl", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "Telephone", c => c.String());
            AddColumn("dbo.QuestRooms", "Logo", c => c.String());
            AddColumn("dbo.QuestRooms", "Address_AddressId", c => c.Int());
            AddColumn("dbo.QuestRooms", "Company_CompanyId", c => c.Int());
            CreateIndex("dbo.QuestRooms", "Address_AddressId");
            CreateIndex("dbo.QuestRooms", "Company_CompanyId");
            AddForeignKey("dbo.QuestRooms", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.QuestRooms", "Company_CompanyId", "dbo.Companies", "CompanyId");
            DropColumn("dbo.Addresses", "AddressHouseNumber");
            DropColumn("dbo.QuestRooms", "QuestRoomName");
            DropColumn("dbo.QuestRooms", "QuestRoomDuration");
            DropColumn("dbo.QuestRooms", "QuestRoomMaxPlayers");
            DropColumn("dbo.QuestRooms", "QuestRoomMinPlayers");
            DropColumn("dbo.QuestRooms", "QuestRoomMinAge");
            DropColumn("dbo.QuestRooms", "QuestRoomEmail");
            DropColumn("dbo.QuestRooms", "QuestRoomCompany");
            DropColumn("dbo.QuestRooms", "QuestRoomRating");
            DropColumn("dbo.QuestRooms", "QuestRoomFearLvl");
            DropColumn("dbo.QuestRooms", "QuestRoomComplexityLvl");
            DropColumn("dbo.QuestRooms", "QuestRoomTelephon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestRooms", "QuestRoomTelephon", c => c.String());
            AddColumn("dbo.QuestRooms", "QuestRoomComplexityLvl", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomFearLvl", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomRating", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomCompany", c => c.String());
            AddColumn("dbo.QuestRooms", "QuestRoomEmail", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomMinAge", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomMinPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomMaxPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRooms", "QuestRoomDuration", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.QuestRooms", "QuestRoomName", c => c.String());
            AddColumn("dbo.Addresses", "AddressHouseNumber", c => c.String());
            DropForeignKey("dbo.Photos", "Room_QuestRoomId", "dbo.QuestRooms");
            DropForeignKey("dbo.QuestRooms", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.QuestRooms", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.QuestRooms", new[] { "Company_CompanyId" });
            DropIndex("dbo.QuestRooms", new[] { "Address_AddressId" });
            DropIndex("dbo.Photos", new[] { "Room_QuestRoomId" });
            DropColumn("dbo.QuestRooms", "Company_CompanyId");
            DropColumn("dbo.QuestRooms", "Address_AddressId");
            DropColumn("dbo.QuestRooms", "Logo");
            DropColumn("dbo.QuestRooms", "Telephone");
            DropColumn("dbo.QuestRooms", "ComplexityLvl");
            DropColumn("dbo.QuestRooms", "FearLvl");
            DropColumn("dbo.QuestRooms", "Rating");
            DropColumn("dbo.QuestRooms", "Email");
            DropColumn("dbo.QuestRooms", "MinAge");
            DropColumn("dbo.QuestRooms", "MinPlayers");
            DropColumn("dbo.QuestRooms", "MaxPlayers");
            DropColumn("dbo.QuestRooms", "Duration");
            DropColumn("dbo.QuestRooms", "Description");
            DropColumn("dbo.QuestRooms", "Name");
            DropColumn("dbo.Addresses", "HouseNumber");
            DropTable("dbo.Photos");
            DropTable("dbo.Companies");
            RenameIndex(table: "dbo.Addresses", name: "IX_Street_StreetId", newName: "IX_StreetAddress_StreetId");
            RenameIndex(table: "dbo.Addresses", name: "IX_Country_CountryId", newName: "IX_CountryAddress_CountryId");
            RenameIndex(table: "dbo.Addresses", name: "IX_City_CityId", newName: "IX_CityAddress_CityId");
            RenameColumn(table: "dbo.Addresses", name: "Street_StreetId", newName: "StreetAddress_StreetId");
            RenameColumn(table: "dbo.Addresses", name: "Country_CountryId", newName: "CountryAddress_CountryId");
            RenameColumn(table: "dbo.Addresses", name: "City_CityId", newName: "CityAddress_CityId");
        }
    }
}
