using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Interfaces;
using TodosManagement.Core.Model.DomainEvents;

namespace TodosManagement.Core.Services.EventHandlers
{
    public class EnviarEmailAposNovaTarefaCriada : IHandle<NovaTarefaCriadaEvent>
    {
        readonly IEmailService _emailService;

        public EnviarEmailAposNovaTarefaCriada(IEmailService emailClient)
        {
            _emailService = emailClient;
        }

        public void Handle(NovaTarefaCriadaEvent @event)
        {
            string to = @event.Tarefa.Responsavel;
            const string subject = "Nova tarefa criada";
            var body = string.Format("A tareda {0} foi criada para você por: {1} às {2}",
                @event.Tarefa.Title,
                @event.Autor,
                @event.DateTimeEventOccurred
                );

            _emailService.Send(to, subject, body);
        }
    }
}
