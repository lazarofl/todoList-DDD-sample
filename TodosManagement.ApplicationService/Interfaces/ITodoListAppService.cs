using System.Collections.Generic;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.ApplicationService.Interfaces
{
    public interface ITodoListAppService
    {
        TodoList AdicionarTodoList(string titulo, string resposavel);

        TodoList Find(System.Guid id);

        TodoItem AdicionarTarefa(System.Guid id, string titulo, string responsavel);

        void ConcluirTodoList(System.Guid id);

        IEnumerable<TodoList> ObterTodas(string search);

        void ReabrirTodoList(System.Guid id);
    }
}
