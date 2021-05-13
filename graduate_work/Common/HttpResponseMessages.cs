public static class HttpResponseMessages
{
    public const string BadToken = "Token was error.";
    public const string ExpiredToken = "Link expired, try again.";

    public const string RegistrationUserBad = "User have incorrect data.";
    public const string RegistrationUserExistByLogin = "Account with such login is already registered.";
    public const string RegistrationUserExistByEmail= "Account with such an email is already registered.";
    public const string RegistrationUserBadEmail = "Email are wrong.";
    public const string RegistrationUserBadRole = "Account role is incorrect.";
    public const string RegistrationSchoolExistByName = "School with such an name is already registered.";
    public const string RegistrationSuccess = "Check your email to confirm registration.";

    public const string BadPassword = "Password must be longer than 8 characters and less than 32.";

    public const string EmailNotExist = "Account with such an email is not exist.";
    public const string PasswordNotMatch = "Password and repeated password do not match.";
    public const string RestoreCheckEmail = "Please check your email for password recovery.";
    public const string RestoredSuccess = "Your password success restored!";

    public const string SignInFailed = "Your email or password are wrong!";
    public const string SignInSuccess = "You have successfully logged in!";
    public const string SignOutSuccess = "You sign out success!";
}