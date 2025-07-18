using API.Data;
using API.Dtos.Stock;
using API.EndPoints;
using API.Mappers;
using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]

public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepo;
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context, IStockRepository stockRepo)
    {
        _stockRepo = stockRepo;
        _context = context;
    }

    [HttpGet(ApiEndPoints.Stocks.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async  Task<IActionResult> GetAll()
    {
        var stocks = await _stockRepo.GetAllAsync();
        var stockDto = stocks.Select(x => x.ToStockDto());
        return Ok(stockDto);

    }

    [HttpGet(ApiEndPoints.Stocks.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var stock = await _stockRepo.GetByIdAsync(id);
        if (stock is null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost(ApiEndPoints.Stocks.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]

    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
      
        var stockModel = stockDto.ToStockFromCreateDto();
        await _stockRepo.CreateAsync(stockModel);
        await  _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = stockModel.Id }, stockModel.ToStockDto());

    }

    [HttpPut(ApiEndPoints.Stocks.Update)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
        if (stockModel is null)
        {
            return NotFound();
        }
        
        return Ok(stockModel.ToStockDto());

    }

    [HttpDelete(ApiEndPoints.Stocks.Delete)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult>  Delete([FromRoute] int id)
    {
        var stockModel = await _stockRepo.DeleteAsync(id);
        if (stockModel is null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    }