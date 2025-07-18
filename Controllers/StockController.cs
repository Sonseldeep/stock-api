using API.Data;
using API.Dtos.Stock;
using API.EndPoints;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]

public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(ApiEndPoints.Stocks.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async  Task<IActionResult> GetAll()
    {
        var stocks = await _context.Stocks
            .AsNoTracking()
            .Select(x => x.ToStockDto())
            .ToListAsync();
        return Ok(stocks);

    }

    [HttpGet(ApiEndPoints.Stocks.GetById)]
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

    [HttpPost(ApiEndPoints.Stocks.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]

    public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
    {
      
        var stockModel = stockDto.ToStockFromCreateDto();
        _context.Stocks.Add(stockModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = stockModel.Id }, stockModel.ToStockDto());

    }

    [HttpPut(ApiEndPoints.Stocks.Update)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        var stockModel = _context.Stocks.SingleOrDefault(x => x.Id == id);
        if (stockModel is null)
        {
            return NotFound();
        }

        stockModel.Symbol = updateDto.Symbol;
        stockModel.CompanyName = updateDto.CompanyName;
        stockModel.Purchase = updateDto.Purchase;
        stockModel.LastDiv = updateDto.LastDiv;
        stockModel.Industry = updateDto.Industry;
        stockModel.MarketCap = updateDto.MarketCap;

        _context.SaveChanges();
        return Ok(stockModel.ToStockDto());

    }

    [HttpDelete(ApiEndPoints.Stocks.Delete)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] int id)
    {
        var stockModel = _context.Stocks.SingleOrDefault(x => x.Id == id);
        if (stockModel is null)
        {
            return NotFound();
        }

        _context.Stocks.Remove(stockModel);
        _context.SaveChanges();
        return NoContent();
    }
    
    }