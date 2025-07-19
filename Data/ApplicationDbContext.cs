using AlmaCarne.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmaCarne.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CorteCarne>? CortesCarne { get; set; }
    }
}

