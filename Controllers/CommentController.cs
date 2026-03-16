using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentsController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public ActionResult<List<Comment>> GetComments()
    {
        return _commentService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Comment> GetComment(int id)
    {
        var comment = _commentService.GetById(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public ActionResult<Comment> AddComment(Comment comment)
    {
        var addedComment = _commentService.Add(comment);
        return CreatedAtAction(nameof(GetComment), new { id = addedComment.Id }, addedComment);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteComment(int id)
    {
        _commentService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Comment> UpdateComment(int id, Comment updatedComment)
    {
        var comment = _commentService.Update(id, updatedComment);
        if (comment == null)
        {
            return NotFound();
        }
        return comment;
    }
}