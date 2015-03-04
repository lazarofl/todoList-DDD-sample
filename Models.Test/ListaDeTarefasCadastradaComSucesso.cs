using System.Linq;
using TodosManagement.Core.Model.TodosAggregate;
using Xunit;

namespace Models.Test
{
    [Trait("Cadastro de uma lista de tarefas válida", "")]
    public class ListaDeTarefasValida
    {
        [Fact(DisplayName = "ao cadastrar uma lista de tarefa com título e usuario associados")]
        public void CadastraComTituloeUsuario()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", usuario: "lazaro");

            Assert.True(todoList.IsValid);
            Assert.Empty(todoList.BrokenRules);
        }


    }
}
