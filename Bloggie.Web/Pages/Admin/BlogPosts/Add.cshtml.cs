using System.Text.Json;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        private readonly IBlogpostRepository blogpostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        public AddModel(IBlogpostRepository blogpostRepository) 
        {
            this.blogpostRepository = blogpostRepository;
        }

        public void OnGet()
        {
        
        }

        public async Task<IActionResult> OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandler = AddBlogPostRequest.UrlHandler,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visable = AddBlogPostRequest.Visable,
            };

            await blogpostRepository.AddAsync(blogPost);

            var notificaiton = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New blog created!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notificaiton);


            return RedirectToPage("/Admin/BlogPosts/List");
        }
    }
}
