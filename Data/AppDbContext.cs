using Microsoft.EntityFrameworkCore;
using TaskManagerPoC.Models;

namespace TaskManagerPoC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Esse DbSet representa a tabela no banco
    public DbSet<TodoTask> Tasks => Set<TodoTask>();
}