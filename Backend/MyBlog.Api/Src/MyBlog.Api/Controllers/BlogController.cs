using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MyBlog.Api.ViewModels.Blog;
using MyBlog.Common.Enums;
using MyBlog.Common.Models;
using MyBlog.DAL.Data;
using MyBlog.Models.Blog;
using System.Linq;

namespace MyBlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly MyBlogContext _context;

        public BlogController(MyBlogContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BlogCreateViewModel blogCreateViewModel)
        {
            try
            {
                var blog = new Blog()
                {
                    Title = blogCreateViewModel.Title,
                    Description = blogCreateViewModel.Description
                };

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {

                    await _context.Blogs.AddAsync(blog);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }

                return Ok(new ResponseModel
                {
                    Message = "Blog post creaded successfully.",
                    BlogStatusCode = MyBlogStatusCode.Created,
                    Data = new { CreatedAt = "api/Blog", Id = blog.Id }
                });
            }
            catch
            {
                return BadRequest(new ResponseModel
                {
                    Message = "Failed to create a blog post.",
                    BlogStatusCode = MyBlogStatusCode.BadRequest
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var blogs = await _context.Blogs.OrderBy(x=>x.CreatedDate).Select(x => new BlogListViewModel
                {
                    Title = x.Title,
                    ShortDescription = x.Description
                }).ToListAsync();

                return Ok(new ResponseModel
                {
                    Message = "Blogs fetched successfully.",
                    BlogStatusCode = MyBlogStatusCode.Ok,
                    Data = blogs
                });
            }
            catch
            {
                return BadRequest(new ResponseModel
                {
                    Message = "Failed to fetch blogs.",
                    BlogStatusCode = MyBlogStatusCode.BadRequest
                });
            }
        }
    }
}
