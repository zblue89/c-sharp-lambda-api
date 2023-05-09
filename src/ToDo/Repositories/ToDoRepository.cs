using Amazon.DynamoDBv2.DataModel;
using ToDo.Entities;

namespace ToDo.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IDynamoDBContext dynamoDBContext;

        public ToDoRepository(IDynamoDBContext dynamoDBContext)
        {
            this.dynamoDBContext = dynamoDBContext;
        }

        public async Task<ToDoItem> CreateToDo(string userId, string details)
        {
            var item = new ToDoItem
            {
                UserId = userId,
                Id = Guid.NewGuid().ToString(),
                Details = details
            };
            await dynamoDBContext.SaveAsync<ToDoItem>(item);
            return item;
        }

        public async Task<List<ToDoItem>> GetToDos(string userId)
        {
            var search = dynamoDBContext.QueryAsync<ToDoItem>(userId);
            var result = new List<ToDoItem>();
            do
            {
                result.AddRange(await search.GetNextSetAsync());
            }
            while (!search.IsDone);
            return result;
        }

        public async Task<ToDoItem?> GetToDo(string userId, string id)
        {
            return await dynamoDBContext.LoadAsync<ToDoItem>(userId, id);
        }
    }
}