namespace Agile.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactDatas", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ContactDatas", "LastName", c => c.String());
            AddColumn("dbo.ContactDatas", "EmailAddress", c => c.String(nullable: false));
            AddColumn("dbo.ContactDatas", "PhoneNumber", c => c.String());
            AddColumn("dbo.ContactDatas", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactDatas", "StreetAddress");
            DropColumn("dbo.ContactDatas", "PhoneNumber");
            DropColumn("dbo.ContactDatas", "EmailAddress");
            DropColumn("dbo.ContactDatas", "LastName");
            DropColumn("dbo.ContactDatas", "FirstName");
        }
    }
}
