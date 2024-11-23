using System.Text.Json;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly IBlogpostRepository blogpostRepository;

        [BindProperty]
        public BlogPost BlogPost{ get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogpostRepository blogpostRepository)
        {
            this.blogpostRepository = blogpostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await blogpostRepository.GetAsync(id);

            if (BlogPost != null && BlogPost.Tags != null)
            {
                Tags = string.Join(",", BlogPost.Tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                BlogPost.Tags = new List<Tag>(Tags.Split(",").Select(x => new Tag() { Name = x.Trim().Replace(" ", "-") }));

                await blogpostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Record was successful saved!",
                };
            }
            catch (Exception e)
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Something went wrong!",
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogpostRepository.DeleteAsync(BlogPost.Id);
            
            if(deleted)
            {
                var notificaiton = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog post deleted!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notificaiton);

                return RedirectToPage("/Admin/Blogposts/List");
            }

            return Page();
        }
    }
}
