using System;
using System.Collections.Generic;
using System.Linq;
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

            if (!todolist.IsValid)
                throw new ApplicationException("To-do List não é válida");

            _repository.Insert(todolist);

            return todolist;
        }

        public TodoList Find(Guid id)
        {
            return _repository.Find(id);
        }


        public TodoItem AdicionarTarefa(Guid id, string titulo, string responsavel)
        {
            var todolist = _repository.Find(id);
            var tarefa = todolist.AdicionarTarefa(titulo, responsavel);
      
            if (!todolist.IsValid)
                throw new ApplicationException("Tarefa não é válida");

            _repository.Update(todolist);
            return tarefa;
        }

        public void ConcluirTodoList(Guid id)
        {
            var todolist = _repository.Find(id);
            todolist.Concluir(usuario: @"Administrador");
            _repository.Update(todolist);
        }

        public void ReabrirTodoList(Guid id)
        {
            var todolist = _repository.Find(id);
            todolist.Reabrir(usuario: @"Administrador");
            _repository.Update(todolist);
        }

    }
}
