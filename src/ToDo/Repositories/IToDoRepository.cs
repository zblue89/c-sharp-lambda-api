using ToDo.Entities;

namespace ToDo.Repositories
{
    public interface IToDoRepository
    {

        public Task<ToDoItem> CreateToDo(string userId, string details);

        public Task<List<ToDoItem>> GetToDos(string userId);

        public Task<ToDoItem?> GetToDo(string userId, string id);
    }
}