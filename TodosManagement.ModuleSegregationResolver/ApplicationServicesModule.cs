using Ninject.Modules;
using TodosManagement.ApplicationService.ConcreteServices;
using TodosManagement.ApplicationService.Interfaces;

namespace TodosManagement.ModuleSegregationResolver
{
    public class ApplicationServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITodoListAppService>().To<TodoListAppService>();
        }
    }
}
