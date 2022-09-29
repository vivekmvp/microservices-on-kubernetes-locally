using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace backend.Models
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
