using System.Collections.Generic;
using TheBlogApplication.Models;

namespace TheBlogApplication.ViewModels
{
    public class PostDetailViewModel
    {
        public Post Post { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
