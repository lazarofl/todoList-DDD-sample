namespace TodosManagement.Core.Interfaces
{
    public interface IEmailService
    {
        void Send(string emailAddress, string subject, string body);
    }
}
