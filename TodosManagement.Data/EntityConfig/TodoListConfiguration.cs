using System.Data.Entity.ModelConfiguration;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.Data.EntityConfig
{
    public class TodoListConfiguration : EntityTypeConfiguration<TodoList>
    {

        public TodoListConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Usuario)
                .IsRequired();

        }

    }
}
