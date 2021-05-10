namespace graduate_work.Models.Api
{
    public class NewSchoolMember
    {
        public NewSchoolMember() { }

        public NewSchoolMember(string Login, string Password, string Email, string Role)
        {
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.Role = Role;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
