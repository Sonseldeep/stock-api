using API.EndPoints;
using API.Mappers;
using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepo;
    public CommentController(ICommentRepository commentRepo)
    {
        _commentRepo = commentRepo;
    }

    [HttpGet(ApiEndPoints.Comments.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentRepo.GetAllAsync();
        var commentDto = comments.Select(x => x.ToCommentDto());
        return Ok(commentDto);

    }

    [HttpGet(ApiEndPoints.Comments.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromBody] int id)
    {
        var comment = await _commentRepo.GetByIdAync(id);
        if (comment is null)
        {
            return NotFound();
        }

        return Ok(comment.ToCommentDto());
    }
}