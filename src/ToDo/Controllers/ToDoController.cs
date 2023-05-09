using Microsoft.AspNetCore.Mvc;
using ToDo.Repositories;
using ToDo.Models;
using ToDo.Entities;

namespace ToDo.Controllers;

[ApiController]
[Route("/v1/todo")]
public class ToDoController : ControllerBase
{
    private const string FakeUserId = "fake-user";
    private readonly IToDoRepository toDoRepository;

    public ToDoController(IToDoRepository toDoRepository)
    {
        this.toDoRepository = toDoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ToDoItem>>> GetAll()
    {
        var items = await toDoRepository.GetToDos(FakeUserId);
        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItem>> Create([FromBody] CreateToDoRequest request)
    {
        var item = await toDoRepository.CreateToDo(FakeUserId, request.Details);
        return CreatedAtAction("GetOne", new { id = item.Id }, item);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetOne(string id)
    {
        var item = await toDoRepository.GetToDo(FakeUserId, id);
        return Ok(item);
    }

}
