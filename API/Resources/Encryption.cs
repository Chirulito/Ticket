using System.Security.Cryptography;
using System.Text;

public class Encryption
{
    public static string EncryptPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public static bool VerifyPassword(string password, string encryptedPassword)
    {
        string hashedInput = EncryptPassword(password);
        return string.Equals(hashedInput, encryptedPassword, StringComparison.OrdinalIgnoreCase);
    }
}

