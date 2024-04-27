namespace Blog;
using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext
{
    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
}

public class Blog
{
    public int BlogId { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }

    public virtual List<Post> Posts { get; set; } = new List<Post>();
}

public class Post
{
    public int PostId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }

    public required int BlogId { get; set; }
    public virtual Blog? Blog { get; set; }
}