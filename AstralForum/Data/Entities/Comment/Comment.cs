﻿using System.Xml.Linq;

namespace AstralForum.Data.Entities.Comment
{
    public class Comment : MetadataBaseEntity
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reaction.Reaction> Reactions { get; set; }
        public List<CommentAttachment> Attachments { get; set; }
    }
}