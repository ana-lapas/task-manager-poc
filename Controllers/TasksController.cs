using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerPoC.Data;
using TaskManagerPoC.Models;

namespace TaskManagerPoC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // CREATE: POST api/tasks
    [HttpPost]
    public async Task<ActionResult<TodoTask>> PostTask(TodoTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // READ: GET api/tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    // READ (Single): GET api/tasks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoTask>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task == null ? NotFound() : task;
    }

    // UPDATE: PUT api/tasks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, TodoTask task)
    {
        if (id != task.Id) return BadRequest();

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: DELETE api/tasks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // EXPORT: GET api/tasks/export
    [HttpGet("export")]
    public async Task<IActionResult> ExportToCsv()
    {
        var tasks = await _context.Tasks.ToListAsync();
        var builder = new System.Text.StringBuilder();

        // Header do CSV
        builder.AppendLine("Id,Title,Description,IsCompleted,CreatedAt");

        foreach (var task in tasks)
        {
            // Sanitização simples para CSV
            builder.AppendLine($"{task.Id},{task.Title},{task.Description},{task.IsCompleted},{task.CreatedAt:yyyy-MM-dd HH:mm:ss}");
        }

        var csvContent = System.Text.Encoding.UTF8.GetBytes(builder.ToString());
        return File(csvContent, "text/csv", "tasks_export.csv");
    }
}