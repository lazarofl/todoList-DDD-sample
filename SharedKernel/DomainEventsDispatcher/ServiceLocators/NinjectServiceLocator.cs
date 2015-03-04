using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace SharedKernel.DomainEventsDispatcher.ServiceLocators
{
    public class NinjectServiceLocator : ServiceLocatorImplBase
    {
        public IKernel Kernel { get; private set; }

        public NinjectServiceLocator(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected override System.Collections.Generic.IEnumerable<object> DoGetAllInstances(System.Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        protected override object DoGetInstance(System.Type serviceType, string key)
        {
            return key == null
                ? Kernel.Get(serviceType)
                : Kernel.Get(serviceType, key);
        }
    }
}
