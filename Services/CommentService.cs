using portfolio_api.Models;
using portfolio_api.Data;

namespace portfolio_api.Services;

public class CommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context)
    {
        _context = context;
    }

    public List<Comment> GetAll()
    {
        return _context.Comments.ToList();
    }

    public Comment? GetById(int id)
    {
        return _context.Comments.FirstOrDefault(c => c.Id == id);
    }

    public Comment Add(Comment comment)
    {
        comment.Date = DateTime.UtcNow;

        _context.Comments.Add(comment);
        _context.SaveChanges();

        return comment;
    }

    public Comment? Update(int id, Comment updatedComment)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment == null) return null;

        comment.Name = updatedComment.Name;
        comment.Message = updatedComment.Message;
        comment.Date = DateTime.UtcNow;

        _context.SaveChanges();

        return comment;
    }

    public void Delete(int id)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}