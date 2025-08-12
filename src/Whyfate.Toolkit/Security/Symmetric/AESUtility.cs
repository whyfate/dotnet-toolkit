using System.Security.Cryptography;
using System.Text;

namespace Whyfate.Toolkit.Security.Symmetric;

/// <summary>
/// aes utility.
/// </summary>
public class AesUtility
{
    /// <summary>
    /// ECB Encrypt.
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string Encrypt(string plainText, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.Mode = CipherMode.ECB; // 设置为ECB模式
        aes.Padding = PaddingMode.PKCS7; // 使用PKCS7填充模式

        using MemoryStream memoryStream = new MemoryStream();
        using CryptoStream cryptoStream =
            new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
        cryptoStream.FlushFinalBlock();

        return Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// ECB Decrypt.
    /// </summary>
    /// <param name="cipherText"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string Decrypt(string cipherText, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.Mode = CipherMode.ECB; // 设置为ECB模式
        aes.Padding = PaddingMode.PKCS7; // 使用PKCS7填充模式

        using MemoryStream memoryStream = new MemoryStream();
        using CryptoStream cryptoStream =
            new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
        cryptoStream.FlushFinalBlock();

        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    /// <summary>
    /// CBC Encrypt.
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <returns></returns>
    public static string Encrypt(string plainText, string key, string iv)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = ivBytes;

        using MemoryStream memoryStream = new MemoryStream();
        using CryptoStream cryptoStream =
            new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
        cryptoStream.FlushFinalBlock();

        return Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// CBC Decrypt.
    /// </summary>
    /// <param name="cipherText"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <returns></returns>
    public static string Decrypt(string cipherText, string key, string iv)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using Aes aes = Aes.Create();
        aes.Key = keyBytes;
        aes.IV = ivBytes;

        using MemoryStream memoryStream = new MemoryStream();
        using CryptoStream cryptoStream =
            new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
        cryptoStream.FlushFinalBlock();

        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
}