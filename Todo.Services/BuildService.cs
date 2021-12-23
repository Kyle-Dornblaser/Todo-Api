using Microsoft.Extensions.DependencyInjection;
using Todo.Services.Model;
using Todo.Services.Repository;

namespace Todo.Services
{
    public static class BuildService
    {
        public static IServiceCollection AddTodoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository<TodoList>, TodoListRepository>();
            serviceCollection.AddScoped<ITaskRepository, TaskRepository>();
            return serviceCollection;
        }
    }
}
