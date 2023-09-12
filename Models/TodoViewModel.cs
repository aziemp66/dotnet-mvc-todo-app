using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_mvc_todo_app.Models
{
    public class TodoViewModel
    {
        public required string Title { get; set; }
        public bool IsDone { get; set; }
    }
}