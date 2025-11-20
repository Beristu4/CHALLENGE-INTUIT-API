using CHALLENGE_INTUIT.Models;
using Microsoft.EntityFrameworkCore;

namespace CHALLENGE_INTUIT
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { } 
        public DbSet<Clients> Clients { get; set; }
    }
}
