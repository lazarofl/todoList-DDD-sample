using Ninject.Modules;
using TodoListManagement.Data;
using TodoListManagement.Data.Repositories;
using TodosManagement.Core.Interfaces;

namespace TodosManagement.ModuleSegregationResolver
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            var context = new TodosManagementContext();

            Bind<ITodoListRepository>().To<TodoListRepository>()
                .WithConstructorArgument("context", context);
        }
    }
}
