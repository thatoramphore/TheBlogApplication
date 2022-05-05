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
    public class Blog
    {
        public int Id { get; set; }     //PK
        public string BlogUserId { get; set; }    //FK

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [DataType(DataType.Date)]   //extract only date
        [Display(Name = "Created Date")]    //label
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]   //extract only date

        [Display(Name = "Updated Date")]    //label
        public DateTime? Updated { get; set; }   // ? = nullable, able to hold no value

        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }       //image info
        [Display(Name = "Image Type")]
        public string ContentType { get; set; }     //image type

        [NotMapped]     //NOT stored in the DB
        public IFormFile Image { get; set; }        //the actual image file

        //navigation properties
        [Display(Name = "Author")]
        public virtual BlogUser BlogUser { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
