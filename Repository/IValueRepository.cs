using System.Collections.Generic;
using TemplateDotnetCoreApi.Models;

namespace TemplateDotnetCoreApi.Repository
{
    public interface IValueRepository
    {
        void Add(Value item);
        IEnumerable<Value> GetAll();
        Value Find(long key);
        void Remove(long Id);
        void Update(Value item);
    }
}
