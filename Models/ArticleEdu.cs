using System;

namespace CourseManager.Models
{
    public class ArticleEdu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
