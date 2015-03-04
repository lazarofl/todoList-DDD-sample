using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Web.Models
{
    public class AdicionarTodoItemViewModel
    {
        [Required]
        public Guid TodoListId { get; set; }

        [Required(ErrorMessage = "Preencha o título desta tarefa")]
        [MaxLength(100, ErrorMessage = "Até 100 caracteres permitidos para o título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Preencha o responsável por esta tarefa")]
        [MaxLength(100, ErrorMessage = "Até 100 caracteres permitidos para preencher o responsável pela tarefa")]
        public string Responsavel { get; set; }
    }
}
