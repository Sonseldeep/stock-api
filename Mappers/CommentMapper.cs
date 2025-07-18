using API.Dtos.Comment;
using API.Models;

namespace API.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreateOn = commentModel.CreateOn,
            StockId = commentModel.StockId

        };
    }
}