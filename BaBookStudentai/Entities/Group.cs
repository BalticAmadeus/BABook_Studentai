using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaBookStudentai.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual List<User> GroupUsers { get; set; }
        public virtual List<Event> GroupEvents { get; set; }
    }
}