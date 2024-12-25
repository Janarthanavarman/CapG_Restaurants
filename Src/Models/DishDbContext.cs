using Microsoft.EntityFrameworkCore;
using CapG.Models;

namespace CapG.AppDbContext;
public class DishDbContext : DbContext
{
    public DishDbContext(DbContextOptions<DishDbContext> options)
        : base(options)
    {

         if(!dishCategorys.Any()){
             dishCategorys.AddRange(
            new DishCategorys { DishCategoryID = 1, DishCategoryName = "Starter" },
            new DishCategorys { DishCategoryID = 2, DishCategoryName = "Main Course" },
            new DishCategorys { DishCategoryID = 3, DishCategoryName = "Dessert" }
             );
            SaveChanges();
        }

       if(!spicyLevels.Any()){
        spicyLevels.AddRange(
           new SpicyLevel { SpicyLevelID = 1, SpicyLevelName = "Mild" },
           new SpicyLevel { SpicyLevelID = 2, SpicyLevelName = "Medium" },
           new SpicyLevel { SpicyLevelID = 3, SpicyLevelName = "Hot" }
        );
           SaveChanges();
       }

        if (!dishs.Any())
        {
            dishs.AddRange(
                new Dishs { DishID = 1, DishCode = "DISH001", DishName = "Medu Vada", DishCategoryID = 1, SpicyLevelID = 3, IsAvail = true, Rating = 5, Price = 15.00 },
                new Dishs { DishID = 2, DishCode = "DISH002", DishName = "Sundal", DishCategoryID = 1, SpicyLevelID = 2, IsAvail = true, Rating = 5, Price = 20.00 },
                new Dishs { DishID = 3, DishCode = "DISH003", DishName = "Paniyaram", DishCategoryID = 1, SpicyLevelID = 3, IsAvail = false, Rating = 5, Price = 30.00 },

                new Dishs { DishID = 4, DishCode = "DISH004", DishName = "Chettinad Chicken Curry", DishCategoryID = 2, SpicyLevelID = 3, IsAvail = true, Rating = 5, Price = 180.00 },
                new Dishs { DishID = 5, DishCode = "DISH005", DishName = "Kootu", DishCategoryID = 2, SpicyLevelID = 1, IsAvail = true, Rating = 5, Price = 15.00 },
                new Dishs { DishID = 6, DishCode = "DISH006", DishName = "Thambrani Rice (Tambram Rice)", DishCategoryID = 2, SpicyLevelID = 2, IsAvail = false, Rating = 5, Price = 35.00 },

                new Dishs { DishID = 7, DishCode = "DISH007", DishName = "Payasam", DishCategoryID = 3, SpicyLevelID = 3, IsAvail = true, Rating = 5, Price = 15.00 },
                new Dishs { DishID = 8, DishCode = "DISH008", DishName = "Kesari", DishCategoryID = 3, SpicyLevelID = 3, IsAvail = true, Rating = 5, Price = 15.00 },
                new Dishs { DishID = 9, DishCode = "DISH009", DishName = "Halwa", DishCategoryID = 3, SpicyLevelID = 3, IsAvail = false, Rating = 5, Price = 25.00 }
            );
            SaveChanges();
        }

       
    }

    public DbSet<Dishs> dishs { get; set; }
    public DbSet<DishCategorys> dishCategorys { get; set; }
    public DbSet<SpicyLevel> spicyLevels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Enable lazy loading proxies
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DishCategorys>().HasKey(a => a.DishCategoryID);
        modelBuilder.Entity<SpicyLevel>().HasKey(a => a.SpicyLevelID);
        modelBuilder.Entity<Dishs>().HasKey(a => a.DishID);
       
       modelBuilder.Entity<Dishs>()
            .HasOne(d => d.DishCategory)   // Dish has one DishCategory
            .WithMany(dc => dc.Dishs)    // DishCategory has many Dishes
            .HasForeignKey(d => d.DishCategoryID) // The foreign key in Dish table
            .OnDelete(DeleteBehavior.Cascade);  // Define the delete behavior (optional)

        modelBuilder.Entity<Dishs>()
            .HasOne(d => d.SpicyLevel)   // Dish has one DishCategory
            .WithMany(dc => dc.Dishs)    // DishCategory has many Dishes
            .HasForeignKey(d => d.SpicyLevelID) // The foreign key in Dish table
            .OnDelete(DeleteBehavior.Cascade);  // Define the delete behavior (optional)
        
    }

}