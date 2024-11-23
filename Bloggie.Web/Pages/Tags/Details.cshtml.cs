using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogpostRepository blogpostRepository;

        public List<BlogPost> Blogs{ get; set; }

        public DetailsModel(IBlogpostRepository blogpostRepository)
        {
            this.blogpostRepository = blogpostRepository;
        }
        public async Task<IActionResult> OnGet(string tagName)
        {
            Blogs = (await blogpostRepository.GetAllAsync(tagName)).ToList();

            return Page();
        }
    }
}
