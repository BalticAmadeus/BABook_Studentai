using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int CreatorId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        
        public string Comment { get; set; }
        [StringLength(100)]
        public string Location { get; set; }

    }
}