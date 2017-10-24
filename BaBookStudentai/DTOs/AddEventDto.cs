using System;

namespace BaBookStudentai.DTOs
{
    public class AddEventDto
    {
        public int GroupId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
    }
}