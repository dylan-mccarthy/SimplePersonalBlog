namespace SimplePersonalBlog.Data;
public class BlogPost
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Author { get; set;}
    public string[]? Tags { get; set; }
    public DateTime Created { get; set; }

}