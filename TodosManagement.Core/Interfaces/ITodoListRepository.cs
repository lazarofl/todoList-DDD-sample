using System;
using System.Collections.Generic;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.Core.Interfaces
{
    public interface ITodoListRepository : IRepository<TodoList, Guid>
    {
        IEnumerable<TodoList> ObterAbertas();
        IEnumerable<TodoList> ObterFechadas();
        IEnumerable<TodoList> ObterDe(string responsavel);
        TodoList ObterDeUmaTodoItem(Guid guid);
    }
}
