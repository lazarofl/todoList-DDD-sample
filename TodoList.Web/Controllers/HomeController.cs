using System;
using System.Linq;
using System.Web.Mvc;
using TodoList.Web.Models;
using TodosManagement.ApplicationService.Interfaces;
using TodosManagement.Core.Model.TodosAggregate;

namespace TodoList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoListAppService _todoListApp;

        public HomeController(ITodoListAppService todoListApp)
        {
            _todoListApp = todoListApp;
        }

        [HttpGet]
        public ActionResult Index(string search)
        {
            var todolist = _todoListApp.ObterTodas(search);
            return View(todolist.ToList());
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            AdicionarTodoListViewModel model = new AdicionarTodoListViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Adicionar(AdicionarTodoListViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _todoListApp.AdicionarTodoList(model.Titulo, model.Responsavel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Tarefas(Guid Id)
        {
            var todoList = _todoListApp.Find(Id);
            return View(todoList);
        }

        [HttpGet]
        public ActionResult AdicionarTarefa(Guid Id)
        {
            AdicionarTodoItemViewModel model = new AdicionarTodoItemViewModel();
            model.TodoListId = Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult AdicionarTarefa(AdicionarTodoItemViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            TodoItem todoitem = _todoListApp.AdicionarTarefa(model.TodoListId, model.Titulo, model.Responsavel);

            return RedirectToAction("Tarefas", "Home", new { Id = todoitem.TodoListId });
        }

        [HttpGet]
        public ActionResult Concluir(Guid id)
        {
            _todoListApp.ConcluirTodoList(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Reabrir(Guid id)
        {
            _todoListApp.ReabrirTodoList(id);

            return RedirectToAction("Index");
        }

    }
}