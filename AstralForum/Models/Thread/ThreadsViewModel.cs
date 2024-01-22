﻿using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AstralForum.Models.Thread
{
    public class ThreadsViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public Image? Photo { get; set; }
        public int Category { get; set; }
    }
}
