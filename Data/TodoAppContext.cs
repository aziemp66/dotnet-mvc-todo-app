using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_mvc_todo_app.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc_todo_app.Data
{
    public class TodoAppContext : DbContext
    {
    public TodoAppContext(DbContextOptions<TodoAppContext> options) : base(options)
    {
    }
        public DbSet<Todo> Todos { get; set; }
    }
}