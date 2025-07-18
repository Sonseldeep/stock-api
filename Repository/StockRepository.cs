using API.Data;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class StockRepository : IStockRepository
{
    
    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
        
        _context = context;
    }
    
    public Task<List<Stock>> GetAllAsync()
    {
        return _context.Stocks.AsNoTracking().ToListAsync();
    }
}