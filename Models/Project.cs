namespace portfolio_api.Models;

public class Project
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string ImageUrl { get; set; }

    public required string GithubUrl { get; set; }

    public required string LiveUrl { get; set; }

    public DateTime CreatedAt { get; set; }
}