namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            RenameColumn(table: "dbo.Appointments", name: "Patient_Id", newName: "PatientId");
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            AlterColumn("dbo.Appointments", "PatientId", c => c.Int());
            DropColumn("dbo.Appointments", "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "Patient_Id");
            CreateIndex("dbo.Appointments", "Patient_Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.Users", "Id");
        }
    }
}
