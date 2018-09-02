namespace SafePoint.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FIT5032_SafePoint_Models : DbContext
    {
        public FIT5032_SafePoint_Models()
            : base("name=FIT5032_SafePoint_Models")
        {
        }

        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>()
                .Property(e => e.HospName)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.HospType)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.LGA)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.ServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.StreetNum)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.RoadName)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.RoadSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.RoadType)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Hospital>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<Table>()
                .Property(e => e.HospName)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.HospType)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.LGA)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.ServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.StreetNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.RoadName)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.RoadType)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.RoadSuffix)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.State)
                .IsUnicode(false);
        }
    }
}
