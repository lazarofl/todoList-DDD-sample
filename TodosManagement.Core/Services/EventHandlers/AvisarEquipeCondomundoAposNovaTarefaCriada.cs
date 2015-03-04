using SharedKernel.DomainEventsDispatcher.Interfaces;
using TodosManagement.Core.Interfaces;
using TodosManagement.Core.Model.DomainEvents;

namespace TodosManagement.Core.Services.EventHandlers
{
    public class AvisarEquipeCondomundoAposNovaTarefaCriada : IHandle<NovaTarefaCriadaEvent>
    {
        readonly IEmailService _emailService;

        public AvisarEquipeCondomundoAposNovaTarefaCriada(IEmailService emailClient)
        {
            _emailService = emailClient;
        }

        public void Handle(NovaTarefaCriadaEvent @event)
        {
            const string to = "contato@condomundo.com.br";
            const string subject = "LOG: Nova tarefa criada";

            var body = string.Format("A tareda {0} foi criada por {1} para {2}",
                @event.Tarefa.Title,
                @event.Autor,
                @event.Tarefa.Responsavel);

            _emailService.Send(to, subject, body);
        }

    }
}
