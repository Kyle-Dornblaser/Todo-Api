using System;
using System.Collections.Generic;
using Todo.Services.Model;

namespace Todo.Services.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> ListByTodoListId(int todoListId);
    }
}
