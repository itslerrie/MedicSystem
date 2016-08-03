namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Time", c => c.String());
            AlterColumn("dbo.Appointments", "Date", c => c.String());
        }
    }
}
