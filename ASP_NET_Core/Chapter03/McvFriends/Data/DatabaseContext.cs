using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using McvFriends.Models;
namespace McvFriends.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):
            base(options){}
        public DbSet<Friend> Friends{get;set;}
        protected override void OnModelCreating(ModuleBuilder modulebuilder)
        {
            modulebuilder.Entity<Friend>().HasData(
                new Friend{id = 1 ,Name="Mary",Email="Mary@gmail.com",Mobile="0922-355822"},
                new Friend{id = 2 ,Name="David",Email="David@gmail.com",Mobile="0933-123456"},
                new Friend{id = 3 ,Name="Rose",Email="Rose@gmail.com",Mobile="0955-888-163"}
            );
        }
    }
    
}