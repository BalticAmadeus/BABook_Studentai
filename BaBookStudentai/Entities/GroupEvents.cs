using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Entities
{
    public class GroupEvents
    {
        [Key, Column(Order = 0)]
        public int GroupId { get; set; }
        [Key, Column(Order = 1)]
        public int EventId { get; set; }
    }
}