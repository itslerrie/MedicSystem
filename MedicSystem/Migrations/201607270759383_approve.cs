namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approve : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "IsApproved", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "IsApproved", c => c.Boolean(nullable: false));
        }
    }
}
