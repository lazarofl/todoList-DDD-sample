using System.Data.Entity.ModelConfiguration;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodoListManagement.Data.EntityConfig
{
    public class TodoListConfiguration : EntityTypeConfiguration<TodoList>
    {

        public TodoListConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Responsavel)
                .IsRequired()
                .HasMaxLength(150);

            HasMany(x => x.Tarefas)
                .WithRequired(x => x.TodoList)
                .HasForeignKey(x => x.TodoListId)
                .WillCascadeOnDelete(false);

        }

    }
}
