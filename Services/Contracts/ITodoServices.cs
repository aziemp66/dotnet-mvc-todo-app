using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_mvc_todo_app.Models;

namespace dotnet_mvc_todo_app.Services.Contracts
{
    public interface ITodoServices
    {
        List<Todo> GetTodoItems();
        void AddTodoItem(Todo todo);
        void UpdateTodoItem(Todo todo);
    }
}