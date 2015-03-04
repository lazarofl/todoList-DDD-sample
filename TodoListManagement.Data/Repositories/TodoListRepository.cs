using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Models;
using TodosManagement.Core.Interfaces;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodoListManagement.Data.Repositories
{
    public class TodoListRepository : ITodoListRepository, IDisposable
    {
        private readonly TodosManagementContext _context;

        public TodoListRepository(TodosManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoList> ObterAbertas()
        {
            return _context.TodoLists.Where(x => x.Status == TodoListStatus.Open).Include(x => x.Tarefas);
        }

        public IEnumerable<TodoList> ObterFechadas()
        {
            return _context.TodoLists.Where(x => x.Status == TodoListStatus.Done).Include(x => x.Tarefas);
        }

        public IEnumerable<TodoList> ObterDe(string responsavel)
        {
            return _context.TodoLists.Where(x => x.Responsavel == responsavel).Include(x => x.Tarefas);
        }

        public TodoList ObterDeUmaTodoItem(Guid todoListId)
        {
            return _context.TodoLists.Where(x => x.Tarefas.Count(y => y.TodoListId == todoListId) > 0).Include(x => x.Tarefas).First();
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _context.TodoLists.Include(x => x.Tarefas);
        }

        public TodoList Find(Guid id)
        {
            return _context.TodoLists.Where(x => x.Id == id).Include(x => x.Tarefas).First();
        }

        public void Insert(TodoList entity)
        {
            _context.TodoLists.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TodoList entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = this.Find(id);
            _context.TodoLists.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
