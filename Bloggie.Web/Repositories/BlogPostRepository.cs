using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostRepository : IBlogpostRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.FindAsync(id);

            if (existingBlogPost != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlogPost);
                await bloggieDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            Console.WriteLine("did get all");
            return await bloggieDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).ToListAsync();

            //need to change this so that the stored procedure gets the tags for all blog posts
            //return await bloggieDbContext.BlogPosts.FromSqlRaw("EXEC GetAllBlogPosts").ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName)
        {
            return await (bloggieDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .Where(x => x.Tags.Any(x => x.Name == tagName)))
                .ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await bloggieDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<BlogPost> GetAsync(string urlHandle)
        {
            return await bloggieDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.UrlHandler == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandler = blogPost.UrlHandler;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visable = blogPost.Visable;
                
                if(blogPost.Tags != null && blogPost.Tags.Any())
                {
                    //Delete the existing tags
                    bloggieDbContext.Tags.RemoveRange(existingBlogPost.Tags);

                    //Add new tags
                    blogPost.Tags.ToList().ForEach(x => x.BlogPostId = existingBlogPost.Id);
                    await bloggieDbContext.Tags.AddRangeAsync(blogPost.Tags);
                }
            }

            await bloggieDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
