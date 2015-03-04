namespace TodoListManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databsae : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        Usuario = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        Status = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false, precision: 0),
                        TodoListId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(maxLength: 2000, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TodoList", t => t.TodoListId)
                .Index(t => t.TodoListId);
            
            CreateTable(
                "dbo.TodoList",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        Responsavel = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        LastUpdate = c.DateTime(nullable: false, precision: 0),
                        Status = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItem", "TodoListId", "dbo.TodoList");
            DropIndex("dbo.TodoItem", new[] { "TodoListId" });
            DropTable("dbo.TodoList");
            DropTable("dbo.TodoItem");
        }
    }
}
