namespace TodoListManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizadoonomedecoluna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItem", "Responsavel", c => c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"));
            DropColumn("dbo.TodoItem", "Usuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TodoItem", "Usuario", c => c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"));
            DropColumn("dbo.TodoItem", "Responsavel");
        }
    }
}
