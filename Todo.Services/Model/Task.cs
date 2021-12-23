namespace Todo.Services.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TodoListId { get; set; }
    }
}
