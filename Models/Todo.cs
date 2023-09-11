namespace dotnet_mvc_todo_app.Models;

public class Todo
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool IsDone { get; set; }
}