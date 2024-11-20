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

        public List<BlogPost> Blogs { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogpostRepository blogpostRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogpostRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await blogPostRepository.GetAllAsync()).ToList();

            return Page();
        }
    }
}
