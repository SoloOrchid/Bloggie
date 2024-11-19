using System.Text.Json;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
        private readonly IBlogpostRepository blogpostRepository;

        public List<BlogPost> BlogPosts { get; set; }


        public ListModel(IBlogpostRepository blogpostRepository) 
        {
            this.blogpostRepository = blogpostRepository;
        }

        public async Task OnGet()
        {
            var notificaitonJson = (string)TempData["Notification"];
            if (notificaitonJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificaitonJson);
            }

            BlogPosts = (await blogpostRepository.GetAllASync())?.ToList();
        }
    }
}
