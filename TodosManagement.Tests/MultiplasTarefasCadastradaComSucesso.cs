using System.Linq;
using TodosManagement.Core.Model.TodosAggregate;
using Xunit;

namespace Models.Test
{
    [Trait("Tentativa de cadastro de várias tarefas válidas dentro de uma lista", "")]
    public class MultiplasTarefasCadastradaComSucesso
    {
        [Fact(DisplayName = "ao cadastrar 3 tarefas com título e usuario associados")]
        public void TentativaDeCadastrarTresTarefas()
        {
            TodoList todoList = TodoList.Create(title: "lista 1", responsavel: "lazaro");

            todoList.AdicionarTarefa("tarefa 1", "usario");
            todoList.AdicionarTarefa("tarefa 2", "usario");
            todoList.AdicionarTarefa("tarefa 3", "usario");

            Assert.True(todoList.IsValid);
            Assert.Equal(3, todoList.Tarefas.Count());
        }


    }
}
