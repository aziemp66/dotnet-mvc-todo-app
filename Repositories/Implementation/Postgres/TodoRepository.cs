using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_mvc_todo_app.Data;
using dotnet_mvc_todo_app.Models;
using dotnet_mvc_todo_app.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace dotnet_mvc_todo_app.Repositories.Implementation.Postgres
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoAppContext dbContext;

        public TodoRepository(TodoAppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Todo todo)
        {
            dbContext.Todos.Add(todo);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await dbContext.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(string id)
        {
            return await dbContext.Todos.FirstAsync(todo => todo.Id == id);
        }

        public async Task UpdateAsync(Todo updatedtodo)
        {
            dbContext.Todos.Update(updatedtodo);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await dbContext.Todos.Where(todo => todo.Id == id).ExecuteDeleteAsync();
        }
    }
}