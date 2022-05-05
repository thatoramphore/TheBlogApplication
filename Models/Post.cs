using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TheBlogApplication.Enums;

namespace TheBlogApplication.Models
{
    public class Post
    {
        public int Id { get; set; }     //PK
        public int BlogId { get; set; } //FK
        public string BlogUserId { get; set; }   //FK

        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime Updated { get; set; }

        //public bool isReady { get; set; }
        [Display(Name = "Ready Status")]
        public ReadyStatus ReadyStatus { get; set; }

        public string Slug { get; set; }

        [Display(Name = "Image Data")]
        public byte[] ImageData { get; set; }
        [Display(Name = "Image Type")]
        public string ContentType { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation properties
        public virtual Blog Blog { get; set; }
        [Display(Name = "Author")]
        public virtual BlogUser BlogUser { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
