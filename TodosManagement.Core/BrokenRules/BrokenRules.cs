namespace TodosManagement.Core.BrokenRules
{
    public class BrokenRoles<T>
    {
        public T BrokenRules { get; private set; }
        public string Message { get; private set; }

        public BrokenRoles(T brokenRules, string message)
        {
            this.BrokenRules = brokenRules;
            this.Message = message;
        }
    }
}
