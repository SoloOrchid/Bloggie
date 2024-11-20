using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    
    public class DetailsModel : PageModel
    {
        private readonly IBlogpostRepository blogpostRepository;
        public BlogPost BlogPost { get; set; }

        public DetailsModel(IBlogpostRepository blogpostRepository)
        {
            this.blogpostRepository = blogpostRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogpostRepository.GetAsync(urlHandle);
            return Page();
        }
    }
}
