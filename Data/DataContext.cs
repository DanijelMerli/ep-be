using Microsoft.EntityFrameworkCore;
using EsportsProphetAPI.Models;

namespace EsportsProphetAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}