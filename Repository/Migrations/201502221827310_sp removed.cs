namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spremoved : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("dbo.Users_Insert");
            DropStoredProcedure("dbo.Users_Update");
            DropStoredProcedure("dbo.Users_Delete");
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
