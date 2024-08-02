using Bombillo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bombillo.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
