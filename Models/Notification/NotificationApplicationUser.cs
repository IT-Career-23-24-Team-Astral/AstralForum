﻿using AstralForum.Data.Entities;

namespace AstralForum.Models.Notification
{
    public class NotificationApplicationUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsRead { get; set; } = false;
        public NotificationModel Notification { get; set; }
    }
}