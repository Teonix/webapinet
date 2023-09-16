using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapinet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Fruit> Fruits => Set<Fruit>();
    }
}