using System.Drawing;

namespace AstralForum.Data.Entities.Threads
{
    public class Threads
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int Category { get; set; }
    }
}
