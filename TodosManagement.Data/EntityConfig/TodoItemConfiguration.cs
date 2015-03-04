using System.Data.Entity.ModelConfiguration;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.Data.EntityConfig
{
    public class TodoItemConfiguration : EntityTypeConfiguration<TodoItem>
    {

        public TodoItemConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Usuario)
                .IsRequired();

            HasRequired(p => p.TodoList)
            .WithMany()
            .HasForeignKey(p => p.TodoListId);

        }

    }
}
