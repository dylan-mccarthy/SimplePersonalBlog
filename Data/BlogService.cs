using Microsoft.EntityFrameworkCore;
using SimplePersonalBlog.Data;

namespace SimplePersonalBlog.Data;

public interface IBlogService
{
    Task<List<BlogPost>> GetPostsAsync();
    Task<BlogPost> GetPostAsync(int id);
    Task<BlogPost> CreatePostAsync(BlogPost post);
    Task<BlogPost> UpdatePostAsync(int id, BlogPost post);
    Task DeletePostAsync(int id);
}

public class BlogService : IBlogService
{
    private readonly ApplicationDbContext _context;

    public BlogService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BlogPost>> GetPostsAsync()
    {
        return await _context.BlogPosts.ToListAsync();
    }

    public async Task<BlogPost> GetPostAsync(int id)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post == null)
        {
            throw new KeyNotFoundException();
        }
        return post;
    }

    public async Task<BlogPost> CreatePostAsync(BlogPost post)
    {
        _context.BlogPosts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<BlogPost> UpdatePostAsync(int id, BlogPost post)
    {
        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task DeletePostAsync(int id)
    {
        var post = await _context.BlogPosts.FindAsync(id);
        if (post == null)
        {
            throw new KeyNotFoundException();
        }
        _context.BlogPosts.Remove(post);
        await _context.SaveChangesAsync();
    }
}