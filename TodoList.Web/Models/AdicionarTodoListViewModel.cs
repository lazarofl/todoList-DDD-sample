using System.ComponentModel.DataAnnotations;

namespace TodoList.Web.Models
{
    public class AdicionarTodoListViewModel
    {
        [Required(ErrorMessage = "Preencha o título desta lista de atividades")]
        [MaxLength(100, ErrorMessage = "Até 100 caracteres permitidos para o título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Preencha o responsável por esta to-do list")]
        [MaxLength(100, ErrorMessage = "Até 100 caracteres permitidos para preencher o responsável pela to-do list")]
        public string Responsavel { get; set; }
    }
}