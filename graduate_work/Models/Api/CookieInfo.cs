namespace graduate_work.Models.Api
{
    public class CookieInfo
    {
        public CookieInfo(int UserId, int SchoolId, string Role, string Email)
        {
            this.UserId = UserId;
            this.SchoolId = SchoolId;
            this.Role = Role;
            this.Email = Email;
        }

        public int UserId { get; set; }
        public int SchoolId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
