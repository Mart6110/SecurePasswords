namespace SecurePasswords.Interfaces
{
    public interface IAuthenticationService
    {
        void RegisterUser(string username, string password);
        bool AuthenticateUser(string username, string password);
    }
}
