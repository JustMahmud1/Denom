using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDenomHome.Dtos.BlogDtos
{
	public class BlogPostDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }
		public string Image { get; set; }
		[NotMapped]
		public IFormFile File { get; set; }
	}
}
