namespace graduate_work.Models.Api
{
    public class RestoreData
    {
        public RestoreData() { }

        public RestoreData(string Email, string NewPassword, string RepeatedNewPassword)
        {
            this.Email = Email;
            this.NewPassword = NewPassword;
            this.RepeatedNewPassword = RepeatedNewPassword;
        }

        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string RepeatedNewPassword { get; set; }
    }
}
