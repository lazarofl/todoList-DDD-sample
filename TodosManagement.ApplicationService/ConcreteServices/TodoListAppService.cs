using System.Collections.Generic;
using System.Linq;
using System.Net;
using TodosManagement.ApplicationService.Interfaces;
using TodosManagement.Core.Interfaces;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodosManagement.ApplicationService.ConcreteServices
{
    public class TodoListAppService : ITodoListAppService
    {
        private readonly ITodoListRepository _repository;

        public TodoListAppService(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TodoList> ObterTodas(string search = null)
        {
            var todolist = _repository.GetAll();

            if (!string.IsNullOrEmpty(search))
                todolist = todolist.Where(x => x.Title.Contains(search));

            return todolist;
        }

        public TodoList AdicionarTodoList(string titulo, string resposavel)
        {
            TodoList todolist = TodoList.Create(titulo, resposavel);

            _repository.Insert(todolist);

            return todolist;
        }

        public TodoList Find(System.Guid id)
        {
            return _repository.Find(id);
        }


        public TodoItem AdicionarTarefa(System.Guid id, string titulo, string responsavel)
        {
            var todolist = _repository.Find(id);
            var tarefa = todolist.AdicionarTarefa(titulo, responsavel);
            return tarefa;
        }

        public void ConcluirTodoList(System.Guid id)
        {
            var todolist = _repository.Find(id);
            todolist.Concluir(usuario: @"Administrador");
            _repository.Update(todolist);
        }

        public void ReabrirTodoList(System.Guid id)
        {
            var todolist = _repository.Find(id);
            todolist.Reabrir(usuario: @"Administrador");
            _repository.Update(todolist);
        }

    }
}
