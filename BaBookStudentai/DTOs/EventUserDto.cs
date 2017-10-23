using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookStudentai.DTOs
{
    public class EventUserDto
    {
        public int EventId { get; set; }
        public string UserId { get; set; }
        public int Status { get; set; }
    }
}