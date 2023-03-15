using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PassBook.Models
{
    public class TransactionDbContext: IdentityDbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options):base(options)
        {
                    
        }
        public DbSet<Transaction> Transactions { get; set; } 
    }
}
