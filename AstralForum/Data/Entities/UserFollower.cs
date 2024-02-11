namespace AstralForum.Data.Entities
{
    public class UserFollower : MetadataBaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string FollowerId { get; set; }

        public User Follower { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
