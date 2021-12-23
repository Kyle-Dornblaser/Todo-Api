using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Services.Model;

namespace Todo.Services.Repository
{
    internal class TaskRepository : ITaskRepository
    {
        // not thread safe
        private static readonly List<Task> _tasks = new()
        {
            new Task() { Id = 1, Name = "Apples", TodoListId = 1 }
        };

        public void Create(Task value)
        {
            var nextId = (_tasks.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
            value.Id = nextId;
            _tasks.Add(value);
        }

        public void Delete(int id)
        {
            var itemToDelete = _tasks.FirstOrDefault(x => x.Id == id);
            if (itemToDelete != null)
            {
                _tasks.Remove(itemToDelete);
            }
        }

        public Task Get(int id)
        {
            return _tasks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Task> List()
        {
            return _tasks;
        }

        public IEnumerable<Task> ListByTodoListId(int todoListId)
        {
            return _tasks.Where(x => x.TodoListId == todoListId);
        }

        public void Update(Task value)
        {
            var index = _tasks.FindIndex(x => x.Id == value.Id);
            if (index >= 0)
            {
                _tasks[index] = value;
            }
        }
    }
}
