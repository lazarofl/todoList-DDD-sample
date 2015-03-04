using Microsoft.Practices.ServiceLocation;
using SharedKernel.DomainEventsDispatcher.Interfaces;

namespace SharedKernel.DomainEventsDispatcher
{
    public static class DomainEvents
    {

        public static void Initialize(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        private static IServiceLocator _serviceLocator;

        public static void Raise<T>(T Event) where T : IDomainEvent
        {
            var handlers = _serviceLocator.GetAllInstances<IHandle<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(Event);
            }
        }

    }
}
