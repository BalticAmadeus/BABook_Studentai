using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Models
{
    public class UserEventModel
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }

    }

}