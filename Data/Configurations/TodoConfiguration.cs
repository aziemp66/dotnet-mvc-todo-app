using dotnet_mvc_todo_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_mvc_todo_app.Data.Configurations;

public class GroceryListConfiguration : IEntityTypeConfiguration<GroceryList>
{
    public void Configure(EntityTypeBuilder<GroceryList> builder)
    {
        builder.Property(grocery => grocery.Price)
            .HasPrecision(6, 2);
    }
}
public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.Property(todo => todo.Id).HasDefaultValueSql("gen_random_uuid()");
    }
}