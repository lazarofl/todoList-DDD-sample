using System;
using TodosManagement.Core.Interfaces;

namespace TodoListManagement.Services
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string emailAddress, string subject, string body)
        {
            Console.WriteLine("enviando email...");
        }
    }
}
