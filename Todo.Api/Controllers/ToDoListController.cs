using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Services.Model;
using Todo.Services.Repository;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IRepository<TodoList> _repository;

        public TodoListController(IRepository<TodoList> repository)
        {
            _repository = repository;
        }

        // GET: api/<TodoListController>
        [HttpGet]
        public IEnumerable<TodoList> Get()
        {
            return _repository.List();
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public TodoList Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/<TodoListController>
        [HttpPost]
        public void Post([FromBody] TodoList value)
        {
            _repository.Create(value);
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoList value)
        {
            value.Id = id;
            _repository.Update(value);
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
