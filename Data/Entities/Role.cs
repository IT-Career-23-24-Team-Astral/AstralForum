using Microsoft.AspNetCore.Identity;

namespace AstralForum.Data.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Color { get; set; }
    }
}
