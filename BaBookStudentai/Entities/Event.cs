using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }

    }
}