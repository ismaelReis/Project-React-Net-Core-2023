using Microsoft.EntityFrameworkCore;
using SidimEsus.Models;

namespace SidimEsus.Repos
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }

        public DbSet<Cidadao> Cidadaos { get; set; }
    }
}
