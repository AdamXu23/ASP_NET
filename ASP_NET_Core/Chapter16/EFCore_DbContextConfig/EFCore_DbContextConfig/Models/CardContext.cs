using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EFCore_DbContextConfig.Models;

namespace EFCore_DbContextConfig.Models
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }

    /*
    public class CardSeedContext : DbContext
    {
        private readonly IConfiguration _config;
        public CardSeedContext(DbContextOptions<CardContext_backup> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CardSqlServerDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card { Id = 1, Name = "Elon Musk", Brief = "特斯拉創辦人 伊隆·馬斯克", Photo = "ElonMusk.jpg", WikiUrl = "https://goo.gl/46xeXx" },
                new Card { Id = 2, Name = "Mark Zuckerberg", Brief = "Facebook創辦人 馬克·祖伯克", Photo = "MarkZuckerberg.jpg", WikiUrl = "https://goo.gl/BktGGA" },
                new Card { Id = 3, Name = "Steve Jobs", Brief = "蘋果創辦人 史提夫·賈伯斯", Photo = "SteveJobs.jpg", WikiUrl = "https://goo.gl/nAiX0y" },
                new Card { Id = 4, Name = "Vader", Brief = "帝國元帥  維達", Photo = "Vader.jpg", WikiUrl = "https://en.wikipedia.org/wiki/Darth_Vader" },
                new Card { Id = 5, Name = "Darth Mual", Brief = "星際大戰 達斯摩", Photo = "DarthMual.jpg", WikiUrl = "https://goo.gl/5obLhX" },
                new Card { Id = 6, Name = "White Twilek", Brief = "星際大戰 女絕地武士Twilek", Photo = "WhiteTwilek.jpg", WikiUrl = "https://goo.gl/reKzAu" }
                );
        }
    }
    */
}
