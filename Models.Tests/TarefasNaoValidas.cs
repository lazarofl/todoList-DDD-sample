using System;
using System.Linq;
using Xunit;

namespace Models.Tests
{
    [Trait("Tentativa de cadastro de tarefas inválidas", "")]
    public class TarefasNaoValidas
    {
        [Fact(DisplayName = "ao cadastrar uma tarefa sem título")]
        public void TentativaDeCadastrarSemTitulo()
        {
            TodoList todoList = TodoList.Create(title: "", usuario: "lazaro");
            Assert.Contains(TodoBrokenRules.Title, todoList.BrokenRules.Select(x => x.TodoBrokenRules));
        }

        [Fact(DisplayName = "ao cadastrar uma tarefa sem associar a um usuário")]
        public void TentativaDeCadastrarSemUsuario()
        {
            TodoList todoList = TodoList.Create(title: "título", usuario: "");
            Assert.Contains(TodoBrokenRules.Usuario, todoList.BrokenRules.Select(x => x.TodoBrokenRules));
        }


    }
}
