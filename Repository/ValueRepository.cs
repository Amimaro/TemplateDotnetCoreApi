using System.Collections.Generic;
using System.Linq;
using TemplateDotnetCoreApi.Models;
using TemplateDotnetCoreApi.Contexts;

namespace TemplateDotnetCoreApi.Repository
{
    public class ValueRepository : IValueRepository
    {
        ValueContext _context;
        static List<Value> ValueList = new List<Value>();

        public ValueRepository(ValueContext context)
        {
            _context = context;
        }

        public void Add(Value item)
        {
            _context.Value.Add(item);
            _context.SaveChanges();
        }

		public IEnumerable<Value> GetAll()
        {
            return _context.Value.ToList();
        }

        public Value Find(long key)
        {
            return ValueList
                .Where(e => e.Id == (key))
                .SingleOrDefault();
        }

        public void Remove(long Id)
        {
            var itemToRemove = ValueList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                ValueList.Remove(itemToRemove);
        }

        public void Update(Value item)
        {
            var itemToUpdate = ValueList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Id = item.Id;
                itemToUpdate.Name = item.Name;
            }
        }
    }
}
