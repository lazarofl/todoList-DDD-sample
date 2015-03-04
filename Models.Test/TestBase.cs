using Microsoft.Practices.ServiceLocation;
using Ninject;
using SharedKernel.DomainEventsDispatcher;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using SharedKernel.DomainEventsDispatcher.ServiceLocators;
using TodosManagement.Core.Model.DomainEvents;
using TodosManagement.Core.Services.EventHandlers;

namespace Models.Test
{
    public class TestBase
    {
        public TestBase()
        {
            IKernel kernel = new StandardKernel();
            IServiceLocator sl = new NinjectServiceLocator(kernel);
            DomainEvents.Initialize(sl);

            kernel.Bind<IHandle<NovaTarefaCriadaEvent>>().To<AvisarEquipeCondomundoAposNovaTarefaCriada>();
            kernel.Bind<IHandle<NovaTarefaCriadaEvent>>().To<EnviarEmailAposNovaTarefaCriada>();
        }
    }
}
