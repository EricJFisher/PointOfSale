using System.Data.Entity;

namespace WebService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
    }
}
