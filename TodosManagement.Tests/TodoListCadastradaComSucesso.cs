using System.Linq;
using Microsoft.Practices.ServiceLocation;
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
    public class TodoListCadastradaComSucesso
    {
        public TodoListCadastradaComSucesso()
        {

            var emailHandler = new Mock<IHandle<NovaTarefaCriadaEvent>>();

            emailHandler.Setup(x => x.Handle(It.IsAny<NovaTarefaCriadaEvent>())).Verifiable();

            IKernel kernel = new StandardKernel();
            IServiceLocator sl = new NinjectServiceLocator(kernel);
            DomainEvents.Initialize(sl);

            kernel.Bind<IHandle<NovaTarefaCriadaEvent>>().ToConstant(emailHandler.Object);
        }

        [Fact(DisplayName = "ao cadastrar uma lista de tarefas com título e usuario associados")]
        public void TarefaComTituloeUsuario()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", responsavel: "lazaro");

            todoList.AdicionarTarefa("tarefa 1", "usario");

            Assert.True(todoList.IsValid);
            Assert.Equal(1, todoList.Tarefas.Count());
        }


    }
}
