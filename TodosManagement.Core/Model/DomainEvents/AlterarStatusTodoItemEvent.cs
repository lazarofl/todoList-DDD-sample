using Models;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.Core.Model.DomainEvents
{
    public class AlterarStatusTodoItemEvent : IDomainEvent
    {
        public TodoItem TodoItem;
        public string Usuario;

        public AlterarStatusTodoItemEvent(TodoItem todoItem, string usuario)
        {
            // TODO: Complete member initialization
            this.TodoItem = todoItem;
            this.Usuario = usuario;
            this.DateTimeEventOccurred = System.DateTime.Now;
        }

        public System.DateTime DateTimeEventOccurred { get; private set; }
    }
}
