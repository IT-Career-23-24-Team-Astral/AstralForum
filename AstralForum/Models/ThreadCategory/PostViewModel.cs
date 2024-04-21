namespace AstralForum.Models.ThreadCategory
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string Title { get; set; }

        public int Likes { get; set; }

        public int RepliesCount { get; set; }

        public int Views { get; set; }

        public string Activity { get; set; }


        public string AuthorId { get; set; }

        public string AuthorProfilePicture { get; set; }

    }
}
