using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogpostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost> GetAsync(Guid Id);
        Task<BlogPost> GetAsync(string urlHandle);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost> UpdateAsync(BlogPost blogPost);

        Task<bool> DeleteAsync(Guid Id);
    }
}
