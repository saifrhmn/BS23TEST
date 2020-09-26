using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BS23TEST.Models
{
    public class BlogPost
    {
        [Key]
        public Guid PostID { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan PostTime { get; set; }
        public string Location { get; set; }
        public virtual User User { get; set; }
    }
}