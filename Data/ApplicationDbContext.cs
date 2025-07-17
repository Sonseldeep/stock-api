using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : DbContext
{
    

    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>().HasData(
            new Stock {Id = 1, Symbol = "AAPL", CompanyName = "Apple Inc.", Purchase = 150.00m, LastDiv = 0.22m, Industry = "Technology", MarketCap = 2500000000000 },
            new Stock {Id = 2, Symbol = "MSFT", CompanyName = "Microsoft Corporation", Purchase = 300.00m, LastDiv = 0.56m, Industry = "Technology", MarketCap = 2000000000000 },
            new Stock {Id = 3, Symbol = "GOOGL", CompanyName = "Alphabet Inc.", Purchase = 2800.00m, LastDiv = 0.00m, Industry = "Technology", MarketCap = 1800000000000 },
            new Stock {Id = 4, Symbol = "AMZN", CompanyName = "Amazon.com Inc.", Purchase = 3500.00m, LastDiv = 0.00m, Industry = "E-commerce", MarketCap = 1700000000000 }
            );
    }
}