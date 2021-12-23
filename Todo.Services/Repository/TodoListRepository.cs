using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Services.Model;

namespace Todo.Services.Repository
{
    internal class TodoListRepository : IRepository<TodoList>
    {
        // not thread safe
        private static readonly List<TodoList> _todoLists = new()
        {
            new TodoList() { Id = 1, Name = "Grocery" }
        };

        public void Create(TodoList value)
        {
            var nextId = (_todoLists.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
            value.Id = nextId;
            _todoLists.Add(value);
        }

        public void Delete(int id)
        {
            var itemToDelete = _todoLists.FirstOrDefault(x => x.Id == id);
            if (itemToDelete != null)
            {
                _todoLists.Remove(itemToDelete);
            }
        }

        public TodoList Get(int id)
        {
            return _todoLists.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TodoList> List()
        {
            return _todoLists;
        }

        public void Update(TodoList value)
        {
            var index = _todoLists.FindIndex(x => x.Id == value.Id);
            if (index >= 0)
            {
                _todoLists[index] = value;
            }
        }
    }
}
