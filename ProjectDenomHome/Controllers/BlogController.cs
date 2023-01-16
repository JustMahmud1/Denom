using Microsoft.AspNetCore.Mvc;
using ProjectDenomHome.DAL;
using ProjectDenomHome.Dtos;
using ProjectDenomHome.Dtos.BlogDtos;
using ProjectDenomHome.Models;

namespace ProjectDenomHome.Controllers
{
	public class BlogController : Controller
	{
		private readonly AppDbContext _context;

		public BlogController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			IQueryable<Blog> blogs = _context.Blogs;
			GetAllDto<BlogGetDto> blogGetDto = new();
			blogGetDto.Items = blogs.Select(b => new BlogGetDto { Id = b.Id, Title = b.Title, Description = b.Description, Date = b.Date, Image = b.Image }).ToList();
			return View(blogGetDto.Items);
		}
	}
}
