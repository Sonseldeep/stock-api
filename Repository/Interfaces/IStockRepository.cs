using API.Models;

namespace API.Repository.Interfaces;

public interface IStockRepository
{
   Task<List<Stock>> GetAllAsync(); 
}