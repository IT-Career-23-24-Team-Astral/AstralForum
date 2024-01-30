using System.Drawing;

namespace AstralForum.Data.Entities.Thread
{
    public class Thread : MetadataBaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int Category { get; set; }
    }
}
