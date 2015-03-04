namespace Models.Core
{
    public class BrokenRoles<T>
    {
        public T TodoBrokenRules { get; private set; }
        public string Message { get; private set; }

        public BrokenRoles(T todoBrokenRules, string message)
        {
            this.TodoBrokenRules = todoBrokenRules;
            this.Message = message;
        }
    }
}
