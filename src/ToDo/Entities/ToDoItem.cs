using Amazon.DynamoDBv2.DataModel;

namespace ToDo.Entities
{
    [DynamoDBTable("ToDo")]
    public class ToDoItem
    {
        [DynamoDBHashKey]
        public string UserId { get; set; }
        [DynamoDBRangeKey]
        public string Id { get; set; }
        public string Details { get; set; }
    }
}