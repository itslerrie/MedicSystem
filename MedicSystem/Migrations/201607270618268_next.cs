namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Doctor_UserId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "Doctor_UserId" });
            DropColumn("dbo.Appointments", "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "Doctor_UserId", newName: "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "UserId");
            RenameIndex(table: "dbo.Appointments", name: "IX_PatientId", newName: "IX_UserId");
            AlterColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            AlterColumn("dbo.Appointments", "DoctorId", c => c.Int());
            RenameIndex(table: "dbo.Appointments", name: "IX_UserId", newName: "IX_PatientId");
            RenameColumn(table: "dbo.Appointments", name: "UserId", newName: "PatientId");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "Doctor_UserId");
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Doctor_UserId");
            AddForeignKey("dbo.Appointments", "Doctor_UserId", "dbo.Doctors", "UserId");
        }
    }
}
