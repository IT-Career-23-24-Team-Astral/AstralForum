﻿using Microsoft.AspNetCore.Identity;

namespace AstralForum.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
