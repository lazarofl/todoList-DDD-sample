using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Moq;
using Ninject;
using SharedKernel.DomainEventsDispatcher;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using SharedKernel.DomainEventsDispatcher.ServiceLocators;
using TodosManagement.Core.Model.DomainEvents;
using TodosManagement.Core.Model.Enums.ModelsStates;
using TodosManagement.Core.Model.TodosAggregate;
using Xunit;

namespace Models.Test
{
    [Trait("Ao marcar uma tarefa como concluída", "")]
    public class MarcarTarefaComoConcluida
    {

        public MarcarTarefaComoConcluida()
        {
            var eventHandler = new Mock<IHandle<AlterarStatusTodoItemEvent>>();

            eventHandler.Setup(x => x.Handle(It.IsAny<AlterarStatusTodoItemEvent>())).Verifiable();

            IKernel kernel = new StandardKernel();
            IServiceLocator sl = new NinjectServiceLocator(kernel);
            DomainEvents.Initialize(sl);

            kernel.Bind<IHandle<AlterarStatusTodoItemEvent>>().ToConstant(eventHandler.Object);
        }

        [Fact(DisplayName = "deve deixar o status da tarefa como Finalizado")]
        public void FinalizarTarefa()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", responsavel: "lazaro");

            var tarefa = todoList.AdicionarTarefa("tarefa 1", "usario");

            todoList.FinalizarTarefa(tarefa, "usuario 2");

            Assert.True(todoList.Tarefas.First().Status == TodoItemStatus.Done);
        }

    }
}
