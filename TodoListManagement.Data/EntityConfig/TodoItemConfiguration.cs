using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodoListManagement.Data.EntityConfig
{
    public class TodoItemConfiguration : EntityTypeConfiguration<TodoItem>
    {

        public TodoItemConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Responsavel)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Description)
                .HasMaxLength(2000);

            HasRequired(t => t.TodoList)
                .WithMany(c => c.Tarefas)
                .HasForeignKey(x => x.TodoListId)
                .WillCascadeOnDelete(false);

        }

    }
}
