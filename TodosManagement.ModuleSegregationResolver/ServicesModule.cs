using Ninject.Modules;
using TodoListManagement.Services;
using TodosManagement.Core.Interfaces;

namespace TodosManagement.ModuleSegregationResolver
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmailService>().To<FakeEmailService>();
        }
    }
}
