using System.Security.Cryptography;

namespace SecurePasswords.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }

        public void SetPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            Salt = salt;

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                PasswordHash = pbkdf2.GetBytes(20);
            }
        }

        public bool VerifyPassword(string password)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Salt, 10000))
            {
                byte[] enteredHash = pbkdf2.GetBytes(20);
                for (int i = 0; i < PasswordHash.Length; i++)
                {
                    if (PasswordHash[i] != enteredHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
