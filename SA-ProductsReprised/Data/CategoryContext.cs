using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext (DbContextOptions<CategoryContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Category> Category { get; set; }
    }
}
