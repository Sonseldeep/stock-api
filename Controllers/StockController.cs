using API.Data;
using API.Dtos.Stock;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Route("api")]
[ApiController]

public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("stocks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var stocks = _context.Stocks
            .AsNoTracking()
            .Select(x => x.ToStockDto())
            .ToList();
        return Ok(stocks);

    }

    [HttpGet("stocks/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        var stock = _context.Stocks.SingleOrDefault(x => x.Id == id);
        if (stock is null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost("stocks")]

    public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
    {
        var stockModel = stockDto.ToStockFromCreateDto();
        _context.Stocks.Add(stockModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = stockModel.Id }, stockModel.ToStockDto());

    }
    
    }