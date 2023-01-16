using Microsoft.AspNetCore.Mvc;
using ProjectDenomHome.DAL;
using ProjectDenomHome.Dtos;
using ProjectDenomHome.Dtos.BlogDtos;
using ProjectDenomHome.Models;

namespace ProjectDenomHome.Areas.Admin.Controllers
    
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

		public BlogController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		public IActionResult Index()
        {
            IQueryable<Blog> blogs = _context.Blogs;
            GetAllDto<BlogGetDto> blogGetDto = new();
            blogGetDto.Items = blogs.Select(b => new BlogGetDto { Id = b.Id, Title = b.Title, Description = b.Description, Date = b.Date, Image = b.Image }).ToList();
            return View(blogGetDto.Items);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogPostDto blogPostDto)
        {
            if (!blogPostDto.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "Content type must be image(png,jpg,jpeg)");
                return View();
            }


            string imgname = Guid.NewGuid() + blogPostDto.File.FileName;
            string path = Path.Combine(_env.WebRootPath,"assets/images",imgname);

            using (FileStream filestream = new FileStream(path,FileMode.Create))
            {
                blogPostDto.File.CopyTo(filestream);
            }
            _context.Blogs.Add(new Blog {Title=blogPostDto.Title,Description=blogPostDto.Description,Date=blogPostDto.Date,Image=imgname });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
