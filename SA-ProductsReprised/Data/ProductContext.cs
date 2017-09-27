using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Product> Product { get; set; }
    }
}
