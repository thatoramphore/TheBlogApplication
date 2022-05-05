using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogApplication.Models
{
    public class Tag
    {
        public int Id { get; set; }             //PK
        public int PostId { get; set; }         //FK
        public string BlogUserId { get; set; }    //FK

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        public string Text { get; set; }

        //Navigation properties
        public virtual Post Post { get; set; }
        [Display(Name = "Author")]
        public virtual BlogUser BlogUser { get; set; }
    }
}
