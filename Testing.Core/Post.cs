using System.ComponentModel.DataAnnotations;

namespace Testing.Core
{
    public class Post
    {

        public int Id { get; set; }

        [Required, MaxLength(90)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}