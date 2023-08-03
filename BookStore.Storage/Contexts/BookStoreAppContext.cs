using BookStore.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Storage.Contexts;

public class BookStoreAppContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }
    
    public virtual DbSet<Book> Books { get; set; }
    
    public virtual DbSet<CartItem> Cart { get; set; }
    
    public virtual DbSet<Order> Orders { get; set; }
    
    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(StorageParameters.ConnectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItem>()
            .HasKey(c => c.IdBook);

        modelBuilder.Entity<Account>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }
}