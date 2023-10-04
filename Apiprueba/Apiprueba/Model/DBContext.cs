using Microsoft.EntityFrameworkCore;

namespace Apiprueba.Model
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public virtual DbSet<TablaPrueba> TablaPrueba { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablaPrueba>(entity =>
            {
                entity.ToTable("TablaPrueba");
                entity.Property(e => e.ColumnaPrueba)
                .HasMaxLength(50)
                .IsUnicode(false);
            });
        }
    }
}
