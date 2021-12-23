using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Services.Model;
using Todo.Services.Repository;

namespace Todo.Api.Controllers
{
    [Route("api/TodoList/{todoListId}/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TodoList/1/<TaskController>
        [HttpGet]
        public IEnumerable<Task> Get(int todoListId)
        {
            return _repository.ListByTodoListId(todoListId);
        }


        // POST api/TodoList/1/<TaskController>
        [HttpPost]
        public void Post(int todoListId, [FromBody] Task value)
        {
            value.TodoListId = todoListId;
            _repository.Create(value);
        }

        // PUT api/TodoList/1/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int todoListId, int id, [FromBody] Task value)
        {
            value.Id = id;
            value.TodoListId = todoListId;
            _repository.Update(value);
        }

        // DELETE api/TodoList/1/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
