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
    public class Comment
    {
        public int Id { get; set; }     //PK
        public int PostId { get; set; }     //FK
        public string BlogUserId { get; set; }    //FK
        public string ModeratorId { get; set; }    //FK

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Comment")]
        public string Body { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }
        [Display(Name = "Moderated Date")]
        public DateTime? Moderated { get; set; }
        [Display(Name = "Deleted Date")]
        public DateTime? Deleted { get; set; }

        [Display(Name = "Moderation Content")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no mre than {1} characters long.", MinimumLength = 2)]
        public string ModeratedBody { get; set; }
        [Display(Name = "Moderation Type")]
        public ModerationType ModerationType { get; set; }

        //Navigation properties
        public virtual Post Post { get; set; }
        [Display(Name = "Author")]
        public virtual BlogUser BlogUser { get; set; }
        public virtual BlogUser Moderator { get; set; }
    }
}
