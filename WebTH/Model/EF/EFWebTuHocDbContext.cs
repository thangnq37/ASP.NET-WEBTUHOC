namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFWebTuHocDbContext : DbContext
    {
        public EFWebTuHocDbContext()
            : base("name=EFWebTuHocDbContext")
        {
        }

        public virtual DbSet<BaiHoc> BaiHoc { get; set; }
        public virtual DbSet<BaiHocTag> BaiHocTag { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<LoaiBaiHoc> LoaiBaiHoc { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiHoc>()
                .Property(e => e.UrlHinh)
                .IsUnicode(false);

            modelBuilder.Entity<BaiHoc>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BaiHoc>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BaiHoc>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<BaiHocTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.BaiHocID)
                .IsFixedLength();

            modelBuilder.Entity<LoaiBaiHoc>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiBaiHoc>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiBaiHoc>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}
