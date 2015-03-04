using Microsoft.Practices.ServiceLocation;
using Models;
using Moq;
using Ninject;
using SharedKernel.DomainEventsDispatcher;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using SharedKernel.DomainEventsDispatcher.ServiceLocators;
using TodosManagement.Core.Model.DomainEvents;
using TodosManagement.Core.Model.TodosAggregate;
using Xunit;

namespace TodosManagement.Tests
{
    [Trait("Tentativa de cadastrar uma lista de tarefas válida", "")]
    public class ReabrirUmaTodoList
    {
        public ReabrirUmaTodoList()
        {

            var emailHandler = new Mock<IHandle<AlterarStatusTodoListEvent>>();

            emailHandler.Setup(x => x.Handle(It.IsAny<AlterarStatusTodoListEvent>())).Verifiable();

            IKernel kernel = new StandardKernel();
            IServiceLocator sl = new NinjectServiceLocator(kernel);
            DomainEvents.Initialize(sl);

            kernel.Bind<IHandle<AlterarStatusTodoListEvent>>().ToConstant(emailHandler.Object);
        }

        [Fact(DisplayName = "ao cadastrar uma lista de tarefas com título e usuario associados")]
        public void TarefaComTituloeUsuario()
        {
            string usuario = "administrador";
            TodoList todoList = TodoList.Create(title: "lista 1", responsavel: "lazaro");

            todoList.Reabrir(usuario);

            Assert.True(todoList.Status == TodoListStatus.Open);
        }

    }
}
