using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using SharedKernel.Models;
using TodosManagement.Core.Model.DomainEvents;
using TodosManagement.Core.Model.Enums.ModelsStates;
using TodosManagement.Core.Model.Enums.Rules;

namespace TodosManagement.Core.Model.TodosAggregate
{
    public class TodoList : EntityContract<TodoListBrokenRules, Guid>
    {
        public string Title { get; private set; }
        public string Responsavel { get; private set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<TodoItem> Tarefas { get; private set; }
        public TodoListStatus Status { get; private set; }
        public DateTime DateCreated { get; private set; }

        private TodoList()
        {
            Tarefas = new List<TodoItem>();
        }

        private TodoList(string title, string responsavel)
        {
            if (string.IsNullOrEmpty(title))
                this.AddBrokenRule(TodoListBrokenRules.Title, "Prencha o título da lista de atividades");

            if (string.IsNullOrEmpty(responsavel))
                this.AddBrokenRule(TodoListBrokenRules.Usuario, "Preencha o usuário responsável por esta lista de atividades");

            this.Tarefas = new List<TodoItem>();
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Responsavel = responsavel;
            this.Status = TodoListStatus.Open;
            this.DateCreated = DateTime.Now;
            this.LastUpdate = DateTime.Now;
        }


        public static TodoList Create(string title, string responsavel)
        {
            return new TodoList(title, responsavel);
        }


        public TodoItem AdicionarTarefa(string title, string usuario)
        {
            var tarefa = TodoItem.Create(this, title, usuario);
            this.Tarefas.Add(tarefa);

            if (IsValid)
            {
                SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new NovaTarefaCriadaEvent(lista: this.Title, autor: this.Responsavel, tarefa: tarefa));
                SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new AlterarStatusTodoListEvent(this, usuario));
            }

            return tarefa;
        }

        public override bool IsValid
        {
            get
            {
                bool isTodoListValid = base.IsValid;
                bool isTodoItensInValid = Tarefas.Any(x => x.IsValid == false);
                return isTodoItensInValid == false && isTodoListValid;
            }
        }


        public void FinalizarTarefa(TodoItem tarefa, string usuario)
        {
            var index = Tarefas.ToList().IndexOf(tarefa);
            this.Tarefas.ElementAt(index).AlterarStatus(TodoItemStatus.Done, usuario);

            if (IsValid)
            {
                SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new AlterarStatusTodoListEvent(this, usuario));
            }
        }

        public void Concluir(string usuario)
        {
            this.Status = TodoListStatus.Done;

            if (IsValid)
                SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new AlterarStatusTodoListEvent(this, usuario));
        }

        public void Reabrir(string usuario)
        {
            this.Status = TodoListStatus.Open;

            if (IsValid)
                SharedKernel.DomainEventsDispatcher.DomainEvents.Raise(new AlterarStatusTodoListEvent(this, usuario));
        }
    }

}
