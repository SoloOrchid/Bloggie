using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogpostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllASync();

        Task<BlogPost> GetAsync(Guid Id);

        Task<BlogPost> AddASync(BlogPost blogPost);

        Task<BlogPost> UpdateAsync(BlogPost blogPost);

        Task<bool> DeleteAsync(Guid Id);
    }
}
