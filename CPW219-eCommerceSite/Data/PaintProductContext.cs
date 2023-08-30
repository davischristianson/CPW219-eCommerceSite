using CPW219_eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Data
{
    public class PaintProductContext : DbContext
    {
        public PaintProductContext(DbContextOptions<PaintProductContext> options) : base(options)
        {

        }

        public DbSet<Paint> Paints { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
