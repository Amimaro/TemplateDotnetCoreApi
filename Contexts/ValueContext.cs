using Microsoft.EntityFrameworkCore;
using TemplateDotnetCoreApi.Models;

namespace TemplateDotnetCoreApi.Contexts
{
    public class ValueContext : DbContext
    {
        public ValueContext(DbContextOptions<ValueContext> options)
            :base(options) { }
        public ValueContext(){ }
        public DbSet<Value> Value { get; set; }
    }
}
