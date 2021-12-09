using Microsoft.EntityFrameworkCore;
using McvFriends.Models;
namespace McvFriends.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):
            base(options){}
            public DbSet<Friend> Friends{get;set;}
    }
}