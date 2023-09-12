using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_mvc_todo_app.Models;

namespace dotnet_mvc_todo_app.Repositories.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task CreateAsync(Todo todo);
        Task UpdateAsync(Todo updatedtodo);
        Task DeleteAsync(int id);
    }
}