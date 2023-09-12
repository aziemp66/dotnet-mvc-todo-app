using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_mvc_todo_app.Models
{
    public static class AsViewModelExtension
    {
        public static TodoViewModel AsViewModel(this Todo todo) =>
        new() { Title = todo.Title, IsDone = todo.IsDone };
    }
}