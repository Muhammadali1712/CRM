using Microsoft.EntityFrameworkCore;
using User.Domain.Entity;

namespace User.Infrastructure.DB;

public partial class MyDbcontext : DbContext, IMyDbcontext
{
    public MyDbcontext()
    {
    }

    public MyDbcontext(DbContextOptions<MyDbcontext> options)
        : base(options)
    {
    }



    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User.Domain.Entity.User> Users { get; set; }

    public virtual DbSet<User1> Users1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=::1;Port=5432;Database=PhoneMarket;user id=postgres;password=2004-12-17");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasIndex(e => e.PhoneId, "IX_Favorites_PhoneId");

            entity.HasIndex(e => e.UserId, "IX_Favorites_UserId");

            entity.HasOne(d => d.Phone).WithMany(p => p.Favorites).HasForeignKey(d => d.PhoneId);

            entity.HasOne(d => d.User).WithMany(p => p.Favorites).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Image1).HasColumnName("Image");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasIndex(e => e.PhoneId, "IX_Posts_PhoneId").IsUnique();

            entity.HasIndex(e => e.UserId, "IX_Posts_UserId");

            entity.HasOne(d => d.Phone).WithOne(p => p.Post).HasForeignKey<Post>(d => d.PhoneId);

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User.Domain.Entity.User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<User1>(entity =>
        {
            entity.ToTable("Users");

            entity.Property(e => e.TelegramUsername).HasColumnName("Telegram_username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
