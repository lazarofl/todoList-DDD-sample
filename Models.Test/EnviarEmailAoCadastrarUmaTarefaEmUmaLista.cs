using Microsoft.Practices.ServiceLocation;
using Moq;
using Ninject;
using SharedKernel.DomainEventsDispatcher;
using SharedKernel.DomainEventsDispatcher.ServiceLocators;
using Xunit;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Model.DomainEvents;
using TodosManagement.Core.Model.TodosAggregate;

namespace Models.Test
{
    [Trait("Enviar email ao cadastrar uma tarefa dentro de uma lista", "")]
    public class EnviarEmailAoCadastrarUmaTarefaEmUmaLista
    {
        public EnviarEmailAoCadastrarUmaTarefaEmUmaLista()
        {

            var emailHandler = new Mock<IHandle<NovaTarefaCriadaEvent>>();

            emailHandler.Setup(x => x.Handle(It.IsAny<NovaTarefaCriadaEvent>())).Verifiable();

            IKernel kernel = new StandardKernel();
            IServiceLocator sl = new NinjectServiceLocator(kernel);
            DomainEvents.Initialize(sl);

            kernel.Bind<IHandle<NovaTarefaCriadaEvent>>().ToConstant(emailHandler.Object);
        }

        [Fact(DisplayName = "destinatário deve ser o usuário responsável pela tarefa")]
        public void Responsavel()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", usuario: "lazaro");
            todoList.AdicionarTarefa(title: "tarefa 1", usuario: "lazaro");

            Assert.True(todoList.IsValid);
        }

    }
}
