using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
namespace TodoApi.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
private static readonly List<TodoItem> _todos = new()
{
new TodoItem { Id = 1, Name = "Học REST API", IsComplete = fals
};
// GET: api/todo
[HttpGet]
public ActionResult<IEnumerable<TodoItem>> GetTodos()
{
return Ok(_todos);
}
// GET: api/todo/1
[HttpGet("{id}")]
public ActionResult<TodoItem> GetTodo(int id)
{
var todo = _todos.FirstOrDefault(t => t.Id == id);
if (todo == null) return NotFound();
return Ok(todo);
}
// POST: api/todo
[HttpPost]
public ActionResult<TodoItem> CreateTodo([FromBody] TodoItem todo)
{
    todo.Id = _todos.Max(t => t.Id) + 1; // Tạo ID mới
_todos.Add(todo);
return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, t
}
// PUT: api/todo/1
[HttpPut("{id}")]
public IActionResult UpdateTodo(int id, [FromBody] TodoItem updated
{
var todo = _todos.FirstOrDefault(t => t.Id == id);
if (todo == null) return NotFound();
todo.Name = updatedTodo.Name;
todo.IsComplete = updatedTodo.IsComplete;
return NoContent();
}
// DELETE: api/todo/1
[HttpDelete("{id}")]
public IActionResult DeleteTodo(int id)
{
var todo = _todos.FirstOrDefault(t => t.Id == id);
if (todo == null) return NotFound();
_todos.Remove(todo);
return NoContent();
}
}
}