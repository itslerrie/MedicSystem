namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Address");
        }
    }
}
