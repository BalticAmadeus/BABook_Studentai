using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Entities
{
    public class EventComment
    {
        [Key]
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public string UserComment { get; set; }
    }
}