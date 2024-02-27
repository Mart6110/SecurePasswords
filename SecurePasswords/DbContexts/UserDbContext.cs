using Microsoft.EntityFrameworkCore;
using SecurePasswords.Models;

namespace SecurePasswords.DbContexts
{
    public class UserDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
    }
}
