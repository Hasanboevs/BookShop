using System.Security.Cryptography;
using System.Text;

namespace BookShop.Infrastucture;

public static class StringExtensions
{
    public static string Encrypt(this string password)
    {
        using(var sha256Hash =  SHA256.Create())
        {
            var hashedBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            var hashedPassowrd = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return hashedPassowrd;
        }
    }
}
