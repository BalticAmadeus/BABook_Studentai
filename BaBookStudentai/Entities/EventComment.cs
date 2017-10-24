using System.ComponentModel.DataAnnotations;

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