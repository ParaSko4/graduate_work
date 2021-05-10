namespace graduate_work.Models.Api
{
    public class RestoreData
    {
        public RestoreData() { }

        public RestoreData(string Jwt, string NewPassword, string RepeatedNewPassword)
        {
            this.Jwt = Jwt;
            this.NewPassword = NewPassword;
            this.RepeatedNewPassword = RepeatedNewPassword;
        }

        public string Jwt { get; set; }
        public string NewPassword { get; set; }
        public string RepeatedNewPassword { get; set; }
    }
}
