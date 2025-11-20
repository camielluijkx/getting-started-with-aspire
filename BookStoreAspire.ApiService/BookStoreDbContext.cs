using Microsoft.EntityFrameworkCore;

namespace BookStoreAspire.ApiService;

public sealed class BookStoreDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(builder =>
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(b => b.Price)
                .HasColumnType("numeric(10,2)");
        });
    }
}