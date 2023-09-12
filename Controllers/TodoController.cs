using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_mvc_todo_app.Data;
using dotnet_mvc_todo_app.Data.Migrations;
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

        public async Task<IActionResult> Index()
        {
            var Todos = await todoRepository.GetAllAsync();
            var todoList = Todos.Select(todo => todo.AsViewModel()).ToList();
            return View(todoList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}