namespace Blog;
using Microsoft.EntityFrameworkCore;

public class BlogService
{
    private BloggingContext _context;

    public BlogService(BloggingContext context)
    {
        _context = context;
    }

    public Blog AddBlog(string name, string url)
    {
        var blog = _context.Blogs.Add(new Blog { Name = name, Url = url });
        _context.SaveChanges();
        return blog.Entity;
    }

    public List<Blog> GetAllBlogs()
    {
        var query = _context.Blogs.OrderBy(x => x.Name);
        return query.ToList();
    }

    public async Task<List<Blog>> GetAllBlogsAsync()
    {
        var query = _context.Blogs.OrderBy(x => x.Name);
        return await query.ToListAsync();
    }
}