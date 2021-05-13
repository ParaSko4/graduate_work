using Microsoft.AspNetCore.Http;

namespace graduate_work.Models.Api
{
    public class SchoolRegistrationInfo
    {
        public SchoolRegistrationInfo(string Login, string Password, string Email, string SchoolName, 
            string SchoolLocation, string SchoolEmail, string SchoolNumber)
        {
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.SchoolName = SchoolName;
            this.SchoolLocation = SchoolLocation;
            this.SchoolEmail = SchoolEmail;
            this.SchoolNumber = SchoolNumber;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string SchoolName { get; set; }
        public string SchoolLocation { get; set; }
        public string SchoolEmail { get; set; }
        public string SchoolNumber { get; set; }
    }
}