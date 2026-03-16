namespace portfolio_api.Models;

public class Comment
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Message { get; set; }
    public required DateTime Date { get; set; }
}