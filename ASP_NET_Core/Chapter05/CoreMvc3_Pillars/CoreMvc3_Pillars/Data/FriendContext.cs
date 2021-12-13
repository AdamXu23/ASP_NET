using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreMvc3_Pillars.Models;

namespace CoreMvc3_Pillars.Models
{
    public class FriendContext : DbContext
    {
        public FriendContext (DbContextOptions<FriendContext> options)
            : base(options)
        {
        }

        public DbSet<CoreMvc3_Pillars.Models.Friend> Friend { get; set; }

        public DbSet<CoreMvc3_Pillars.Models.Employee> Employee { get; set; }
    }
}
