using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TodosManagement.Core.Model.TodosAggregate;
using TodosManagement.Data.EntityConfig;

namespace TodosManagement.Data
{
    public class TodosManagementContext : DbContext
    {
        public TodosManagementContext()
            : base(nameOrConnectionString: "DefaultDataBaseConnection")
        {
        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new TodoListConfiguration());
            modelBuilder.Configurations.Add(new TodoItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
