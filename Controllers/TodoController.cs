using System.Diagnostics;
using dotnet_mvc_todo_app.Models;
using dotnet_mvc_todo_app.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mvc_todo_app.Controllers
{
    public class TodoController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ITodoRepository todoRepository;

        public TodoController(ILogger<HomeController> logger, ITodoRepository todoRepository)
        {
            _logger = logger;
            this.todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Todos = await todoRepository.GetAllAsync();
            var todoList = Todos.Select(todo => todo.AsViewModel()).ToList();
            return View(todoList);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var todo = await todoRepository.GetByIdAsync(id);
            return View(todo.AsViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoViewModel todo)
        {
            await todoRepository.CreateAsync(new Todo()
            {
                Title = todo.Title,
                IsDone = todo.IsDone
            });

            return RedirectToAction("Index", "Todo");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var todo = await todoRepository.GetByIdAsync(id);

            return View(todo.AsViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Update(TodoViewModel todoViewModel)
        {
            var todo = await todoRepository.GetByIdAsync(todoViewModel.Id);

            todo.Title = todoViewModel.Title;
            todo.IsDone = todoViewModel.IsDone;

            await todoRepository.UpdateAsync(todo);

            return RedirectToAction("Get", "Todo", new
            {
                id = todoViewModel.Id
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}