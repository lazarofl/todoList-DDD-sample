using Models;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.Core.Model.DomainEvents
{
    public class AlterarStatusTodoListEvent : IDomainEvent
    {
        public TodoList TodoList;
        public string Usuario;

        public AlterarStatusTodoListEvent(TodoList todoList, string usuario)
        {
            this.TodoList = todoList;
            this.Usuario = usuario;
            this.DateTimeEventOccurred = System.DateTime.Now;
        }

        public System.DateTime DateTimeEventOccurred { get; private set; }
    }
}
