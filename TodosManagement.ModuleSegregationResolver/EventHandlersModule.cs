using Ninject.Modules;
using SharedKernel.DomainEventsDispatcher;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using SharedKernel.DomainEventsDispatcher.ServiceLocators;
using TodosManagement.Core.Model.DomainEvents;
using TodosManagement.Core.Services.EventHandlers;

namespace TodosManagement.ModuleSegregationResolver
{
    public class EventHandlersModule : NinjectModule
    {
        public override void Load()
        {
            DomainEvents.Initialize(new NinjectServiceLocator(this.Kernel));
            Bind<IHandle<AlterarStatusTodoItemEvent>>().To<AtualizarDataDeAtualizacaoAposAlterarTodoItem>();
            Bind<IHandle<AlterarStatusTodoListEvent>>().To<AtualizarDataDeAtualizacaoAposAlterarTodoList>();
            Bind<IHandle<NovaTarefaCriadaEvent>>().To<AvisarEquipeCondomundoAposNovaTarefaCriada>();
            Bind<IHandle<NovaTarefaCriadaEvent>>().To<EnviarEmailAposNovaTarefaCriada>();
        }
    }
}
