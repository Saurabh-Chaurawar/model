using Products.Models;
using Microsoft.EntityFrameWorkCore;

namespace Products.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products{get;set}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
    }
}