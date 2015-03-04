using System;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Interfaces;
using TodosManagement.Core.Model.DomainEvents;

namespace TodosManagement.Core.Services.EventHandlers
{
    public class AtualizarDataDeAtualizacaoAposAlterarTodoList : IHandle<AlterarStatusTodoListEvent>
    {
        private readonly ITodoListRepository _repository;

        public AtualizarDataDeAtualizacaoAposAlterarTodoList(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AlterarStatusTodoListEvent @event)
        {
            @event.TodoList.LastUpdate = DateTime.Now;
            _repository.Update(@event.TodoList);
        }
    }
}
