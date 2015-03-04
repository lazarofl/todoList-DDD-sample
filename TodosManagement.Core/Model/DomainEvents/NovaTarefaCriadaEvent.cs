using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.Core.Model.DomainEvents
{
    public class NovaTarefaCriadaEvent : IDomainEvent
    {
        public string Lista { get; private set; }
        public string Autor { get; private set; }
        public TodoItem Tarefa { get; private set; }

        public NovaTarefaCriadaEvent(string lista, string autor, TodoItem tarefa)
        {
            // TODO: Complete member initialization
            this.Lista = lista;
            this.Autor = autor;
            this.Tarefa = tarefa;
            this.DateTimeEventOccurred = System.DateTime.Now;
        }


        public System.DateTime DateTimeEventOccurred { get; private set; }
    }
}
