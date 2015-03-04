using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TodoListManagement.Data.EntityConfig;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodoListManagement.Data
{
    public class TodosManagementContext : DbContext
    {
        public TodosManagementContext()
            : base("TodoDB")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }

        static TodosManagementContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
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
