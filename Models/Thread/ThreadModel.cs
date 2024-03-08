﻿using Microsoft.Build.Framework;

namespace AstralForum.Models
{
    public class ThreadModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int ThreadCategory { get; set; }
        [Required]
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
