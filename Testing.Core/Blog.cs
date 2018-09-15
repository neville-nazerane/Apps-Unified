using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Testing.Core
{
    public class Blog
    {

        public int Id { get; set; }

        [Required, MaxLength(500), Url]
        public string Url { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public List<Post> Posts { get; set; }
    }
}
