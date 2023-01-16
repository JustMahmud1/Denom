using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDenomHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
