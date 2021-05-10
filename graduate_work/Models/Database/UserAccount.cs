using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class UserAccount
    {
        public UserAccount() { }

        public UserAccount(string Login, string Password, string Email, string Role)
        {
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.Role = Role;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}