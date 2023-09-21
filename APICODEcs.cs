[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly List<TodoItem> _todos = new List<TodoItem>();

    // GET: api/Todo
    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> Get()
    {
        return _todos;
    }

    // GET: api/Todo/5
    [HttpGet("{id}", Name = "Get")]
    public ActionResult<TodoItem> Get(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return todo;
    }

    // POST: api/Todo
    [HttpPost]
    public IActionResult Post([FromBody] TodoItem todo)
    {
        todo.Id = _todos.Count + 1; // Assign a new ID
        _todos.Add(todo);
        return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
    }

    // PUT: api/Todo/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TodoItem todo)
    {
        var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return NotFound();
        }

        existingTodo.Name = todo.Name; // Update other properties as needed
        return NoContent();
    }

    // DELETE: api/Todo/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        _todos.Remove(todo);
        return NoContent();
    }
}
