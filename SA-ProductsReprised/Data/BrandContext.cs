using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class BrandContext : DbContext
    {
        public BrandContext (DbContextOptions<BrandContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Brand> Brand { get; set; }
    }
}
