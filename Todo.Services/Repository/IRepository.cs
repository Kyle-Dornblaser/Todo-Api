using System;
using System.Collections.Generic;

namespace Todo.Services.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> List();
        T Get(int id);
        void Update(T value);
        void Create(T value);
        void Delete(int id);
    }
}
