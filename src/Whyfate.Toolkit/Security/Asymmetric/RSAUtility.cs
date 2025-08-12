using System.Security.Cryptography;
using System.Text;

namespace Whyfate.Toolkit.Security.Asymmetric;

/// <summary>
/// Rsa utility.
/// </summary>
public static class RsaUtility
{
    /// <summary>
    /// public key.
    /// </summary>
    public static readonly string PublicKey;

    /// <summary>
    /// private key.
    /// </summary>
    public static readonly string PrivateKey;

    /// <summary>
    /// padding.
    /// </summary>
    public static readonly RSAEncryptionPadding Padding;
    
    static RsaUtility()
    {
        var key = GenerateKeys();
        PublicKey = key.PublicKey;
        PrivateKey = key.PrivateKey;
        Padding = RSAEncryptionPadding.OaepSHA256;
    }

    private static (string PublicKey, string PrivateKey) GenerateKeys()
    {
        using RSA rsa = RSA.Create(2048);
        string publicKey = rsa.ExportSubjectPublicKeyInfoPem();
        string privateKey = rsa.ExportRSAPrivateKeyPem();
        return (publicKey, privateKey);
    }

    /// <summary>
    /// encrypt.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Encrypt(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            throw new ArgumentNullException(nameof(data));
        }
        
        return Encrypt(PublicKey, data, Padding);
    }
    
    /// <summary>
    /// encrypt.
    /// </summary>
    /// <param name="publicKey"></param>
    /// <param name="data"></param>
    /// <param name="padding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Encrypt(string publicKey, string data, RSAEncryptionPadding padding)
    {
        if (string.IsNullOrWhiteSpace(publicKey))
        {
            throw new ArgumentNullException(nameof(publicKey));
        }

        if (string.IsNullOrWhiteSpace(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        using RSA rsa = RSA.Create();
        rsa.ImportFromPem(publicKey.ToCharArray());
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        byte[] encryptedBytes = rsa.Encrypt(dataBytes, padding);
        return Convert.ToBase64String(encryptedBytes);
    }

    /// <summary>
    /// decrypt.
    /// </summary>
    /// <param name="encryptedData"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string? Decrypt(string encryptedData)
    {
        if (string.IsNullOrWhiteSpace(encryptedData))
        {
            throw new ArgumentNullException(nameof(encryptedData));
        }
        
        return Decrypt(PrivateKey, encryptedData, Padding);
    }
    
    /// <summary>
    /// decrypt.
    /// </summary>
    /// <param name="privateKey"></param>
    /// <param name="encryptedData"></param>
    /// <param name="padding"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string? Decrypt(string privateKey, string encryptedData, RSAEncryptionPadding padding)
    {
        if (string.IsNullOrWhiteSpace(privateKey))
        {
            throw new ArgumentNullException(nameof(privateKey));
        }

        if (string.IsNullOrWhiteSpace(encryptedData))
        {
            throw new ArgumentNullException(nameof(encryptedData));
        }

        using RSA rsa = RSA.Create();
        try
        {
            rsa.ImportFromPem(privateKey.ToCharArray());
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, padding);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        catch
        {
            // ignored
        }

        return null;
    }

    /// <summary>
    /// try decrypt data.
    /// </summary>
    /// <param name="privateKey"></param>
    /// <param name="encryptedData"></param>
    /// <param name="padding"></param>
    /// <param name="decryptData"></param>
    /// <returns></returns>
    public static bool TryDecryptData(string privateKey, string encryptedData, RSAEncryptionPadding padding, out string? decryptData)
    {
        try
        {
            decryptData = Decrypt(privateKey, encryptedData, padding);
            return true;
        }
        catch
        {
            // ignored
        }

        decryptData = null;
        return false;
    }
}