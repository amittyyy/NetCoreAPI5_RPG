using Microsoft.EntityFrameworkCore;
using NetCoreAPI5.Models;

namespace NetCoreAPI5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<GrocerySet> GrocerySets {get;set;}
    }
}