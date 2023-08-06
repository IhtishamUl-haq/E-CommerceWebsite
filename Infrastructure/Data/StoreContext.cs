using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
