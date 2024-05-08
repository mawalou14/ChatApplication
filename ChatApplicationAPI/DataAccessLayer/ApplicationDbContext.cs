using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApplicationAPI.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
