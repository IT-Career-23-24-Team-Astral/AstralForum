﻿using Microsoft.Build.Framework;

namespace AstralForum.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
        public int CreatedById { get; set; }
        public DateTime Date { get; set; }  
    }
}
