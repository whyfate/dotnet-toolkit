using Whyfate.Toolkit.Security.Symmetric;

namespace Whyfate.Toolkit.Tests.Security.Symmetric;

public class AesUtilityTests
{
    private readonly string _key = "pass.whyfate.com";
    private readonly string _iv = "abcdef9876543210";

    private readonly string _plainText = "{\"a\":\"a\",\"b\":1,\"c\":[],\"d\":true}";

    private readonly string _ecbCipherText = "TLJbqtZLs1vfLrhGgZcAM2M4ExpMN/I599fTU2NVN88=";
    private readonly string _cbcCipherText = "c7iidVI1d8vs4GKYDRhEYe0WI1XXQkcf/7YNGFT4JJY=";

    [Fact]
    public void TestEncrypt()
    {
        var result = AesUtility.Encrypt(_plainText, _key);
        Assert.Equal(_ecbCipherText, result);
    }

    [Fact]
    public void TestDecrypt()
    {
        var result = AesUtility.Decrypt(_ecbCipherText, _key);
        Assert.Equal(_plainText, result);
    }

    [Fact]
    public void TestEncryptCbc()
    {
        var result = AesUtility.Encrypt(_plainText, _key, _iv);
        Assert.Equal(_cbcCipherText, result);
    }

    [Fact]
    public void TestDecryptCbc()
    {
        var result = AesUtility.Decrypt(_cbcCipherText, _key, _iv);
        Assert.Equal(_plainText, result);
    }
}