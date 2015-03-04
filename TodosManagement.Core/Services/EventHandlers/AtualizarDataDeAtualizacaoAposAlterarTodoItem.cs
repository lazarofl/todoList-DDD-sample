using System;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Interfaces;
using TodosManagement.Core.Model.DomainEvents;

namespace TodosManagement.Core.Services.EventHandlers
{
    public class AtualizarDataDeAtualizacaoAposAlterarTodoItem : IHandle<AlterarStatusTodoItemEvent>
    {
        private readonly ITodoListRepository _repository;

        public AtualizarDataDeAtualizacaoAposAlterarTodoItem(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AlterarStatusTodoItemEvent @event)
        {
            @event.TodoItem.LastUpdate = DateTime.Now;

            var todolist = _repository.ObterDeUmaTodoItem(@event.TodoItem.Id);
            _repository.Update(todolist);
        }
    }
}
