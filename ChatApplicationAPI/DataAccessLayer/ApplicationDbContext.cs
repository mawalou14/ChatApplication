using Microsoft.EntityFrameworkCore;

namespace ChatApplicationAPI.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<MessageEntity>
    }
}
