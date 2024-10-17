using Microsoft.EntityFrameworkCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options): base(options)   // Dışardan connection string göndermek için.
        {
            
        }
       public DbSet<Post> Posts => Set<Post>();
       public DbSet<Comment> Comments => Set<Comment>();
       public DbSet<Tag> Tags => Set<Tag>();
       public DbSet<User> Users => Set<User>();
       

       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Comment>()         // foreign keylerçakıştığı için silme işlemi değiştirildi
        .HasOne(c => c.User)               // her bir comment usera aittir
        .WithMany(u => u.Comments)         // bir user bir çok commenta sahip olabilir
        .HasForeignKey(c => c.UserId)      // yorumlar user ıd foreign keyi ile ilişkilendirilebilir
        .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict User silindiğinde commentlar silinmez silme kısıtlanır.

    modelBuilder.Entity<Comment>()
        .HasOne(c => c.Post)                //her bir comment bir posta ait
        .WithMany(p => p.Comments)          // bir post bir çok commenta sahip olabilir
        .HasForeignKey(c => c.PostId)       // yorumlar post ıd foreign keyi ile ilişkilendirilebilir
        .OnDelete(DeleteBehavior.Cascade);  // Bunu bırakabilirsiniz
}

    }

    
}