using System;
using Models;
using SharedKernel.Models;
using TodosManagement.Core.Model.DomainEvents;

namespace TodosManagement.Core.Model.TodosAggregate
{
    public class TodoItem : EntityContract<TodoItemBrokenRules, Guid>
    {
        public string Title { get; private set; }
        public string Responsavel { get; private set; }
        public TodoItemStatus Status { get; private set; }
        public DateTime LastUpdate { get; set; }

        public virtual Guid TodoListId { get; private set; }
        public virtual TodoList TodoList { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Description { get; private set; }

        private TodoItem()
        {
        }

        private TodoItem(TodoList todoList, string title, string responsavel, string description = null)
        {
            this.TodoList = todoList;
            this.TodoListId = TodoList.Id;

            if (string.IsNullOrEmpty(title))
                this.AddBrokenRule(TodoItemBrokenRules.Title, "Preencha o título da tarefa");

            if (string.IsNullOrEmpty(responsavel))
                this.AddBrokenRule(TodoItemBrokenRules.Usuario, "Preencha o responsável por esta tarefa");

            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
            this.Responsavel = responsavel;
            this.Status = TodoItemStatus.Open;
            this.DateCreated = DateTime.Now;
            this.LastUpdate = DateTime.Now;
        }

        public static TodoItem Create(TodoList todoList, string title, string usuario)
        {
            return new TodoItem(todoList, title, usuario);
        }

        public void AlterarStatus(TodoItemStatus status, string usuario)
        {
            this.Status = status;

            if (this.IsValid)
                SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new AlterarStatusTodoItemEvent(this, usuario));
        }

    }

}
