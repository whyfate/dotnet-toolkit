using System.Security.Cryptography;
using System.Text;

namespace Whyfate.Toolkit.Security.Hash;

/// <summary>
/// sha utility.
/// </summary>
public static class ShaUtility
{
    /// <summary>
    /// sha 256.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Sha256(string input)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = sha256.ComputeHash(bytes);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
            sb.Append(b.ToString("x2"));

        return sb.ToString();
    }
}