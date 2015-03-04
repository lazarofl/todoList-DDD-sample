using System.Linq;
using TodosManagement.Core.Model.TodosAggregate;
using Xunit;

namespace Models.Test
{
    [Trait("Tentativa de cadastro uma lista de tarefas inválida", "")]
    public class ListaDeTarefasNaoValidas
    {
        [Fact(DisplayName = "ao cadastrar uma lista de tarefa sem título")]
        public void TentativaDeCadastrarSemTitulo()
        {
            TodoList todoList = TodoList.Create(title: "", usuario: "lazaro");
         
            Assert.False(todoList.IsValid);
            Assert.Contains(TodoListBrokenRules.Title, todoList.BrokenRules.Select(x => x.TodoBrokenRules));
        }

        [Fact(DisplayName = "ao cadastrar uma lista de tarefas sem associar a um usuário")]
        public void TentativaDeCadastrarSemUsuario()
        {
            TodoList todoList = TodoList.Create(title: "título", usuario: "");
           
            Assert.False(todoList.IsValid);
            Assert.Contains(TodoListBrokenRules.Usuario, todoList.BrokenRules.Select(x => x.TodoBrokenRules));
        }
        
    }
}
