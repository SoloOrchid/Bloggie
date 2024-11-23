using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogpostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;

        public List<BlogPost> Blogs { get; set; }
        public List<Tag> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogpostRepository blogpostRepository, ITagRepository tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogpostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await blogPostRepository.GetAllAsync()).ToList();
            Tags = (await tagRepository.GetAllAsync()).ToList();

            return Page();
        }
    }
}
