using TodosManagement.Core.Model.TodosAggregate;
using Xunit;

namespace Models.Test
{
    [Trait("Tentativa de cadastro de tarefa inválida dentro de uma lista de tarefas", "")]
    public class TentativaDeCadastrarTarefasInvalidasNaLista
    {
        [Fact(DisplayName = "ao cadastrar uma tarefa dentro de uma lista de tarefa sem título")]
        public void TentativaDeCadastrarSemTitulo()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", usuario: "lazaro");
            todoList.AdicionarTarefa(title: "", usuario: "lazaro");

            Assert.False(todoList.IsValid);
        }

        [Fact(DisplayName = "ao cadastrar uma lista de tarefas sem associar a um usuário")]
        public void TentativaDeCadastrarSemUsuario()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", usuario: "lazaro");
            todoList.AdicionarTarefa(title: "título", usuario: "");

            Assert.False(todoList.IsValid);
        }

    }
}
